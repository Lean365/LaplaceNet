using System.ComponentModel.DataAnnotations;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    public class PpOrderQueryDto : PagerInfo 
    {
        public string MoPlant { get; set; }
        public string MoOrderType { get; set; }
        public string MoOrderNo { get; set; }
        public string MoOrderItem { get; set; }
        public string MoOrderlot { get; set; }
        public DateTime? BeginMoOrderDate { get; set; }
        public DateTime? EndMoOrderDate { get; set; }
        public int? IsStatus { get; set; }
    }

    /// <summary>
    /// 生产工单输入输出对象
    /// </summary>
    public class PpOrderDto
    {
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelColumn(Name = "Guid")]
        public Guid MoGuid { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        [ExcelColumn(Name = "生产工厂")]
        public string MoPlant { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        [ExcelColumn(Name = "订单类型")]
        public string MoOrderType { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        public string MoOrderNo { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string MoOrderItem { get; set; }

        [ExcelColumn(Name = "批次")]
        public string MoOrderlot { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        public decimal MoOrderQty { get; set; }

        [Required(ErrorMessage = "生产数量不能为空")]
        [ExcelColumn(Name = "生产数量")]
        public decimal MoOrderProQty { get; set; }

        [Required(ErrorMessage = "订单日期不能为空")]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MoOrderDate { get; set; }

        [ExcelColumn(Name = "工艺路线")]
        public string MoOrderRoute { get; set; }

        [ExcelColumn(Name = "序列号")]
        public string MoOrderSerial { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        public int IsStatus { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        [ExcelColumn(Name = "创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}