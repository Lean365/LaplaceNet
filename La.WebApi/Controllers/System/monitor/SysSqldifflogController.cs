using Microsoft.AspNetCore.Mvc;
using La.WebApi.Filters;
using La.Model.System.Dto;
using La.Service.System.IService;

//创建时间：2023-08-17
namespace La.WebApi.Controllers
{
    /// <summary>
    /// 数据差异日志
    /// </summary>
    [Verify]
    [Route("monitor/SysSqldifflog")]
    [ApiExplorerSettings(GroupName = "sys")]
    public class SysSqldifflogController : BaseController
    {
        /// <summary>
        /// 数据差异日志接口
        /// </summary>
        private readonly ISysSqldifflogService _SysSqldifflogService;

        public SysSqldifflogController(ISysSqldifflogService SysSqldifflogService)
        {
            _SysSqldifflogService = SysSqldifflogService;
        }

        /// <summary>
        /// 查询数据差异日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:sqldifflog:list")]
        public IActionResult QuerySysSqldifflog([FromQuery] SysSqldifflogQueryDto parm)
        {
            var response = _SysSqldifflogService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除数据差异日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sys:sqldifflog:delete")]
        [Log(Title = "数据差异日志", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysSqldifflog(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysSqldifflogService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出数据差异日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "数据差异日志", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sys:sqldifflog:export")]
        public IActionResult Export([FromQuery] SysSqldifflogQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SysSqldifflogService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "数据差异日志", "数据差异日志");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}