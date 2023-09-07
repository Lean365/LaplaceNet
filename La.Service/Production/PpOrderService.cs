using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Infra.Extensions;
using La.Model;
using La.Model.System;
using La.Model.Dto;
using La.Model.Production;
using La.Repository;
using La.Service.Production.IProductionService;
using System.Linq;

namespace La.Service.Production
{
    /// <summary>
    /// 生产工单
    /// Service业务层处理
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [AppService(ServiceType = typeof(IPpOrderService), ServiceLifetime = LifeTime.Transient)]
    public class PpOrderService : BaseService<PpOrder>, IPpOrderService
    {
        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOrderDto> GetList(PpOrderQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOrder>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoPlant), it => it.MoPlant == parm.MoPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderType), it => it.MoOrderType == parm.MoOrderType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderNo), it => it.MoOrderNo.Contains(parm.MoOrderNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderItem), it => it.MoOrderItem == parm.MoOrderItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderlot), it => it.MoOrderlot.Contains(parm.MoOrderlot));
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.MoOrderDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginMoOrderDate != null, it => it.MoOrderDate >= parm.BeginMoOrderDate);
            predicate = predicate.AndIF(parm.EndMoOrderDate != null, it => it.MoOrderDate <= parm.EndMoOrderDate);
            predicate = predicate.AndIF(parm.IsStatus != null, it => it.IsStatus == parm.IsStatus);
            var response = Queryable()
                //.OrderBy("MoOrderDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpOrder, PpOrderDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString)
        {
            int count = Count(it => it.MoGuid.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MoGuid"></param>
        /// <returns></returns>
        public PpOrder GetInfo(Guid MoGuid)
        {
            var response = Queryable()
                .Where(x => x.MoGuid == MoGuid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOrder AddPpOrder(PpOrder model)
        {
            return Context.Insertable(model).EnableDiffLogEvent("新增生产工单").ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOrder(PpOrder model)
        {
            //var response = Update(w => w.MoGuid == model.MoGuid, it => new PpOrder()
            //{
            //    MoPlant = model.MoPlant,
            //    MoOrderType = model.MoOrderType,
            //    MoOrderNo = model.MoOrderNo,
            //    MoOrderItem = model.MoOrderItem,
            //    MoOrderlot = model.MoOrderlot,
            //    MoOrderQty = model.MoOrderQty,
            //    MoOrderProQty = model.MoOrderProQty,
            //    MoOrderDate = model.MoOrderDate,
            //    MoOrderRoute = model.MoOrderRoute,
            //    MoOrderSerial = model.MoOrderSerial,
            //    IsStatus = model.IsStatus,
            //    ReMarks = model.ReMarks,
            //    UpdateBy = model.UpdateBy,
            //    UpdateTime = model.UpdateTime,
            //});
            //return response;
            return Update(model, true,model);
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOrder(List<PpOrder> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MoGuid.IsEmpty(), "Guid不能为空")
                .SplitError(x => x.Item.MoPlant.IsEmpty(), "生产工厂不能为空")
                .SplitError(x => x.Item.MoOrderType.IsEmpty(), "订单类型不能为空")
                .SplitError(x => x.Item.MoOrderNo.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.MoOrderItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MoOrderQty.IsEmpty(), "工单数量不能为空")
                .SplitError(x => x.Item.MoOrderProQty.IsEmpty(), "生产数量不能为空")
                .SplitError(x => x.Item.MoOrderDate.IsEmpty(), "订单日期不能为空")
                .SplitError(x => x.Item.IsStatus.IsEmpty(), "状态不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.EnableDiffLogEvent("批量导入生产工单").ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }
    }
}