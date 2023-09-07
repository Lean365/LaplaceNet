using System;
using La.Model;
using La.Model.Dto;
using La.Model.Production;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 生产工单
    /// service接口
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    public interface IPpOrderService : IBaseService<PpOrder>
    {
        /// <summary>
        /// 生产工单
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOrderDto> GetList(PpOrderQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 生产工单
        /// 详情
        /// </summary>
        /// <param name="MoGuid"></param>
        /// <returns></returns>

        PpOrder GetInfo(Guid MoGuid);

        /// <summary>
        /// 生产工单
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOrder AddPpOrder(PpOrder parm);

        /// <summary>
        /// 生产工单
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOrder(PpOrder parm);

        /// <summary>
        /// 导入
        /// 生产工单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOrder(List<PpOrder> list);
    }
}
