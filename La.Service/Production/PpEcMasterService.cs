using System;
using SqlSugar;
using La.Infra.Attribute;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Repository;
using La.Service.Production.IProductionService;
using System.Linq;

namespace La.Service.Production
{
    /// <summary>
    /// 主设变信息表Service业务层处理
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterService : BaseService<PpEcMaster>, IPpEcMasterService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询主设变信息表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm)
        {
            //开始拼装查询条件
            var predicate = Expressionable.Create<PpEcMaster>();

            //搜索条件查询语法参考Sqlsugar
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Contains(parm.EmEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcStatus), it => it.EmEcStatus == parm.EmEcStatus);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcTitle), it => it.EmEcTitle.Contains(parm.EmEcTitle));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcContent), it => it.EmEcContent.Contains(parm.EmEcContent));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcAssigned), it => it.EmEcAssigned == parm.EmEcAssigned);
            predicate = predicate.AndIF(parm.EmEcManageCategory != null, it => it.EmEcManageCategory == parm.EmEcManageCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcImpDept), it => it.EmEcImpDept == parm.EmEcImpDept);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcMaster, PpEcMasterDto>(parm);

            return response;
        }


        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString)
        {
            int count = Count(it => it.EmId.ToString() == entryString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 添加主设变信息表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddPpEcMaster(PpEcMaster parm)
        {
            var response = Insert(parm, it => new
            {
                it.EmEcIssueDate,
                it.EmEcNo,
                it.EmEcDoc,
                it.EmEcStatus,
                it.EmEcTitle,
                it.EmEcContent,
                it.EmEcAssigned,
                it.EmEcLossAmount,
                it.EmEcManageCategory,
                it.EmEcLiaisonNo,
                it.EmEcLiaisonDoc,
                it.EmEcEppLiaisonNo,
                it.EmEcEppLiaisonDoc,
                it.EmEcFppLiaisonNo,
                it.EmEcFppLiaisonDoc,
                it.EmEcExternalNo,
                it.EmEcExternalDoc,
                it.EmEcImpDept,
                it.EmEcEntryDate,
                it.IsModifySop,
                it.ReMark,
                it.CreateBy,
                it.CreateTime,
            });
            return response;
        }

        /// <summary>
        /// 修改主设变信息表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int UpdatePpEcMaster(PpEcMaster parm)
        {
            var response = Update(w => w.EmId == parm.EmId, it => new PpEcMaster()
            {
                EmEcDoc = parm.EmEcDoc,
                EmEcStatus = parm.EmEcStatus,
                EmEcTitle = parm.EmEcTitle,
                EmEcContent = parm.EmEcContent,
                EmEcAssigned = parm.EmEcAssigned,
                EmEcLossAmount = parm.EmEcLossAmount,
                EmEcManageCategory = parm.EmEcManageCategory,
                EmEcLiaisonNo = parm.EmEcLiaisonNo,
                EmEcLiaisonDoc = parm.EmEcLiaisonDoc,
                EmEcEppLiaisonNo = parm.EmEcEppLiaisonNo,
                EmEcEppLiaisonDoc = parm.EmEcEppLiaisonDoc,
                EmEcFppLiaisonNo = parm.EmEcFppLiaisonNo,
                EmEcFppLiaisonDoc = parm.EmEcFppLiaisonDoc,
                EmEcExternalNo = parm.EmEcExternalNo,
                EmEcExternalDoc = parm.EmEcExternalDoc,
                EmEcImpDept = parm.EmEcImpDept,
                EmEcEntryDate = parm.EmEcEntryDate,
                IsModifySop = parm.IsModifySop,
                ReMark = parm.ReMark,
                UpdateBy = parm.UpdateBy,
                UpdateTime = parm.UpdateTime,
            });
            return response;
        }

        /// <summary>
        /// 清空主设变信息表
        /// </summary>
        /// <returns></returns>
        public void TruncatePpEcMaster()
        {
            Truncate();
        }
        #endregion
    }
}