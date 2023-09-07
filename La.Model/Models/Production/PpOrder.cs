using MiniExcelLibs.Attributes;
using La.Infra.Enums;
namespace La.Model.Production
{
    /// <summary>
    /// 生产工单
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [SugarTable("pp_order")]
    public class PpOrder
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid MoGuid { get; set; }

        /// <summary>
        /// 描述 :生产工厂 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产工厂")]

        public string MoPlant { get; set; }

        /// <summary>
        /// 描述 :订单类型 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "订单类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订单类型")]

        public string MoOrderType { get; set; }

        /// <summary>
        /// 描述 :生产订单 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产订单", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产订单")]

        public string MoOrderNo { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]

        public string MoOrderItem { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次")]
        [ExcelColumn(Name = "批次")]

        public string MoOrderlot { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "工单数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工单数量")]

        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 描述 :生产数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "生产数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产数量")]

        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 描述 :订单日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "订单日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 描述 :工艺路线 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工艺路线")]
        [ExcelColumn(Name = "工艺路线")]

        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 描述 :序列号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "序列号")]
        [ExcelColumn(Name = "序列号")]

        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "状态", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "状态")]

        public int IsStatus { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]

        public int IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]

        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :创建者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        [ExcelColumn(Name = "创建者")]

        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :更新者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        [ExcelColumn(Name = "更新者")]

        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? UpdateTime { get; set; }

    }
/// <summary>
    /// 生产工单
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [SugarTable("pp_order")]
    public class PpOrderImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid MoGuid { get; set; }

        /// <summary>
        /// 描述 :生产工厂 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "生产工厂", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产工厂")]
        public string MoPlant { get; set; }

        /// <summary>
        /// 描述 :订单类型 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "订单类型", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订单类型")]
        public string MoOrderType { get; set; }

        /// <summary>
        /// 描述 :生产订单 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "生产订单", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产订单")]
        public string MoOrderNo { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "物料", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "物料")]
        public string MoOrderItem { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "批次")]
        [ExcelColumn(Name = "批次")]
        public string MoOrderlot { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "工单数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "工单数量")]
        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 描述 :生产数量 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "生产数量", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "生产数量")]
        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 描述 :订单日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "订单日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 描述 :工艺路线 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "工艺路线")]
        [ExcelColumn(Name = "工艺路线")]
        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 描述 :序列号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "序列号")]
        [ExcelColumn(Name = "序列号")]
        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "状态", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "状态")]
        public int IsStatus { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :创建者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by",ColumnDescription = "创建者")]
        [ExcelColumn(Name = "创建者")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time",ColumnDescription = "创建时间")]
        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :更新者 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by",ColumnDescription = "更新者")]
        [ExcelColumn(Name = "更新者")]
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time",ColumnDescription = "更新时间")]
        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }

    }
}