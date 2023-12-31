﻿using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;
using La.Model;
using La.Model.System.Dto;
using La.Service.System.IService;

namespace La.WebApi.Controllers.monitor
{
    /// <summary>
    /// 操作日志记录
    /// </summary>
    [Verify]
    [Route("/monitor/operlog")]
    public class SysOperlogController : BaseController
    {
        private ISysOperLogService sysOperLogService;
        private IWebHostEnvironment WebHostEnvironment;
        /// <summary>
        /// 操作接口
        /// </summary>
        /// <param name="sysOperLogService"></param>
        /// <param name="hostEnvironment"></param>
        public SysOperlogController(ISysOperLogService sysOperLogService, IWebHostEnvironment hostEnvironment)
        {
            this.sysOperLogService = sysOperLogService;
            WebHostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="sysOperLog"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult OperList([FromQuery] SysOperLogDto sysOperLog)
        {
            PagerInfo pagerInfo = new(sysOperLog.PageNum, sysOperLog.PageSize);

            sysOperLog.OperName = !HttpContextExtension.IsAdmin(HttpContext) ? HttpContextExtension.GetName(HttpContext) : sysOperLog.OperName;
            var list = sysOperLogService.SelectOperLogList(sysOperLog, pagerInfo);

            return SUCCESS(list, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 删除操作日志
        /// </summary>
        /// <param name="operIds"></param>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.DELETE)]
        [ActionPermissionFilter(Permission = "monitor:operlog:delete")]
        [HttpDelete("{operIds}")]
        public IActionResult Remove(string operIds)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] operIdss = Tools.SpitLongArrary(operIds);
            return SUCCESS(sysOperLogService.DeleteOperLogByIds(operIdss));
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空操作日志", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:operlog:delete")]
        [HttpDelete("clean")]
        public ApiResult ClearOperLog()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            sysOperLogService.CleanOperLog();

            return ToJson(1);
        }

        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "操作日志", BusinessType = BusinessType.EXPORT)]
        [ActionPermissionFilter(Permission = "monitor:operlog:export")]
        [HttpGet("export")]
        public IActionResult Export([FromQuery] SysOperLogDto sysOperLog)
        {
            var list = sysOperLogService.SelectOperLogList(sysOperLog, new PagerInfo(1, 10000));
            var result = ExportExcelMini(list.Result, "操作日志", "操作日志");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}
