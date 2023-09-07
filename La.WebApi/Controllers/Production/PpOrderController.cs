using Microsoft.AspNetCore.Mvc;
using La.Model.System;
using La.Model.Dto;
using La.Model.Production;
using La.Service.Production.IProductionService;
using La.WebApi.Filters;
using MiniExcelLibs;


namespace La.WebApi.Controllers
{
    /// <summary>
    /// 生产工单
    /// API控制器Controller
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [Verify]
    [Route("production/PpOrder")]
    [Tags("生产工单/PpOrder")]
    [ApiExplorerSettings(GroupName = "production")]
    public class PpOrderController : BaseController
    {
        /// <summary>
        /// 生产工单接口
        /// </summary>
        private readonly IPpOrderService _PpOrderService;

        public PpOrderController(IPpOrderService PpOrderService)
        {
            _PpOrderService = PpOrderService;
        }

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:order:list")]
        public IActionResult QueryPpOrder([FromQuery] PpOrderQueryDto parm)
        {
            var response = _PpOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产工单详情
        /// </summary>
        /// <param name="MoGuid"></param>
        /// <returns></returns>
        [HttpGet("{MoGuid}")]
        [ActionPermissionFilter(Permission = "pp:order:query")]
        public IActionResult GetPpOrder(Guid MoGuid)
        {
            var response = _PpOrderService.GetInfo(MoGuid);
            
            var info = response.Adapt<PpOrder>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:order:add")]
        [Log(Title = "生产工单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOrder([FromBody] PpOrderDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误(parameter error)");
            }

           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOrderService.CheckEntryUnique(parm.MoGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)生产工单 '{parm.MoGuid}'失败(failed)，输入的(The entered)生产工单已存在(already exists)"));
            }

            var modal = parm.Adapt<PpOrder>().ToCreate(HttpContext);

            var response = _PpOrderService.AddPpOrder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:order:edit")]
        [Log(Title = "生产工单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOrder([FromBody] PpOrderDto parm)
        {
            var modal = parm.Adapt<PpOrder>().ToUpdate(HttpContext);
            var response = _PpOrderService.UpdatePpOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产工单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:order:delete")]
        [Log(Title = "生产工单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOrder(string ids)
        {
            //针对自增ID
            //string[] idsArr = Tools.SpitIntArrary(ids);
            //针对全局唯一标识符Guid
            Guid[] idsArr = Tools.SpitGuidArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败ID或Guid不能为空（Delete failed, ID or Guid cannot be empty)")); }

            var response = _PpOrderService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出生产工单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产工单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:order:export")]
        public IActionResult Export([FromQuery] PpOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOrderService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据(No data)");
            }
            var result = ExportExcelMini(list, "生产工单", "生产工单");
            return ExportExcel(result.Item2, result.Item1);
        }


        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产工单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "pp:order:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOrder> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOrder>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOrderService.ImportPpOrder(list));
        }

        /// <summary>
        /// 生产工单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产工单模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOrderImportTmpl>() { }, "PpOrderTmpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}