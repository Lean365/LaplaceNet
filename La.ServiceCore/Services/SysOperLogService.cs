using La.Infra;
using La.Infra.Attribute;
using La.Infra.Extensions;
using SqlSugar;
using La.Model;
using La.Model.System;
using La.Model.System.Dto;
using La.Repository;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [AppService(ServiceType = typeof(ISysOperLogService), ServiceLifetime = LifeTime.Transient)]
    public class SysOperLogService : BaseService<SysOperLog>, ISysOperLogService
    {
        /// <summary>
        /// 新增操作日志操作
        /// </summary>
        /// <param name="operLog">日志对象</param>
        public void InsertOperlog(SysOperLog operLog)
        {
            if (operLog.OperParam.Length >= 1000)
            {
                operLog.OperParam = operLog.OperParam[..1000];
            }
            //sysOperLogRepository.AddSysOperLog(operLog);
            Insert(operLog);
        }

        /// <summary>
        /// 查询系统操作日志集合
        /// </summary>
        /// <param name="sysOper">操作日志对象</param>
        /// <returns>操作日志集合</returns>
        public PagedInfo<SysOperLog> SelectOperLogList(SysOperLogQueryDto sysOper)
        {
            sysOper.BeginTime = DateTimeHelper.GetBeginTime(sysOper.BeginTime, -1);
            sysOper.EndTime = DateTimeHelper.GetBeginTime(sysOper.EndTime, 1);

            var exp = Expressionable.Create<SysOperLog>();
            exp.And(it => it.OperTime >= sysOper.BeginTime && it.OperTime <= sysOper.EndTime);
            exp.AndIF(sysOper.Title.IfNotEmpty(), it => it.Title.Contains(sysOper.Title));
            exp.AndIF(sysOper.OperName.IfNotEmpty(), it => it.OperName.Contains(sysOper.OperName));
            exp.AndIF(sysOper.BusinessType != -1, it => it.BusinessType == sysOper.BusinessType);
            exp.AndIF(sysOper.IsStatus != -1, it => it.IsStatus == sysOper.IsStatus);
            exp.AndIF(sysOper.OperParam != null, it => it.OperParam.Contains(sysOper.OperParam));

            return Queryable().Where(exp.ToExpression())
                .OrderBy(x => x.OperId, OrderByType.Desc)
                .ToPage(sysOper);
            //return GetList(exp.ToExpression(), pager, x => x.OperId, OrderByType.Desc);
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        public void CleanOperLog()
        {
            Truncate();
        }

        /// <summary>
        /// 批量删除系统操作日志
        /// </summary>
        /// <param name="operIds">需要删除的操作日志ID</param>
        /// <returns>结果</returns>
        public int DeleteOperLogByIds(long[] operIds)
        {
            return Delete(operIds);
        }

        /// <summary>
        /// 查询操作日志详细
        /// </summary>
        /// <param name="operId">操作ID</param>
        /// <returns>操作日志对象</returns>
        public SysOperLog SelectOperLogById(long operId)
        {
            return GetById(operId);
        }
    }
}
