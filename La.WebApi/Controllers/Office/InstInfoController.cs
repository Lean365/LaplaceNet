using Microsoft.AspNetCore.Mvc;
using La.Model.System;
using La.Model.Dto;
using La.Model.Office;
using La.Service.Office.IOfficeService;
using La.WebApi.Filters;
using MiniExcelLibs;


namespace La.WebApi.Controllers
{
    /// <summary>
    /// 机构信息
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [Verify]
    [Route("office/InstInfo")]
    [Tags("机构信息/InstInfo")]
    [ApiExplorerSettings(GroupName = "office")]
    public class InstInfoController : BaseController
    {
        /// <summary>
        /// 机构信息接口
        /// </summary>
        private readonly IInstInfoService _InstInfoService;

        public InstInfoController(IInstInfoService InstInfoService)
        {
            _InstInfoService = InstInfoService;
        }

        /// <summary>
        /// 查询机构信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:info:list")]
        public IActionResult QueryInstInfo([FromQuery] InstInfoQueryDto parm)
        {
            var response = _InstInfoService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询机构信息详情
        /// </summary>
        /// <param name="IiGuid"></param>
        /// <returns></returns>
        [HttpGet("{IiGuid}")]
        [ActionPermissionFilter(Permission = "inst:info:query")]
        public IActionResult GetInstInfo(Guid IiGuid)
        {
            var response = _InstInfoService.GetInfo(IiGuid);
            
            var info = response.Adapt<InstInfo>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加机构信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:info:add")]
        [Log(Title = "机构信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInstInfo([FromBody] InstInfoDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstInfoService.CheckEntryUnique(parm.IiGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)机构信息 '{parm.IiGuid}'失败(failed)，输入的(The entered)机构信息已存在(already exists)"));
            }

            var modal = parm.Adapt<InstInfo>().ToCreate(HttpContext);

            var response = _InstInfoService.AddInstInfo(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新机构信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:info:edit")]
        [Log(Title = "机构信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInstInfo([FromBody] InstInfoDto parm)
        {
            var modal = parm.Adapt<InstInfo>().ToUpdate(HttpContext);
            var response = _InstInfoService.UpdateInstInfo(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除机构信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "inst:info:delete")]
        [Log(Title = "机构信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstInfo(string ids)
        {
            //针对自增ID
            //string[] idsArr = Tools.SpitIntArrary(ids);
            //针对全局唯一标识符Guid
            Guid[] idsArr = Tools.SpitGuidArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败ID或Guid不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _InstInfoService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出机构信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "机构信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:info:export")]
        public IActionResult Export([FromQuery] InstInfoQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstInfoService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "机构信息", "机构信息");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "机构信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "inst:info:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InstInfo> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstInfo>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstInfoService.ImportInstInfo(list));
        }

        /// <summary>
        /// 机构信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "机构信息模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstInfoImportTmpl>() { }, "InstInfoTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}