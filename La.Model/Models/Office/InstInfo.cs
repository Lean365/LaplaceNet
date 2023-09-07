using MiniExcelLibs.Attributes;
using La.Infra.Enums;
namespace La.Model.Office
{
    /// <summary>
    /// 机构信息
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [SugarTable("inst_info")]
    public class InstInfo
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "Guid")]

        public Guid IiGuid { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "语言", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "语言")]

        public string IiLangkey { get; set; }

        /// <summary>
        /// 描述 :编号 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [ExcelColumn(Name = "编号")]

        public string IiInstCode { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "类别", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "类别")]

        public string IiCategory { get; set; }

        /// <summary>
        /// 描述 :简称 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "简称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "简称")]

        public string IiShortName { get; set; }

        /// <summary>
        /// 描述 :全称 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "全称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "全称")]

        public string IiFullName { get; set; }

        /// <summary>
        /// 描述 :性质 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "性质", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "性质")]

        public string IiNature { get; set; }

        /// <summary>
        /// 描述 :外线 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "外线", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "外线")]

        public string IiOuterPhone { get; set; }

        /// <summary>
        /// 描述 :内线 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "内线", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "内线")]

        public string IiInnerPhone { get; set; }

        /// <summary>
        /// 描述 :传真 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "传真", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "传真")]

        public string IiFax { get; set; }

        /// <summary>
        /// 描述 :邮编 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "邮编")]
        [ExcelColumn(Name = "邮编")]

        public string IiPostalcode { get; set; }

        /// <summary>
        /// 描述 :邮件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "邮件")]
        [ExcelColumn(Name = "邮件")]

        public string IiEmail { get; set; }

        /// <summary>
        /// 描述 :组织代码 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "组织代码", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "组织代码")]

        public string IiOrgCode { get; set; }

        /// <summary>
        /// 描述 :法人 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "法人", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "法人")]

        public string IiCorporate { get; set; }

        /// <summary>
        /// 描述 :地区 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "地区", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "地区")]

        public string IiRegionId { get; set; }

        /// <summary>
        /// 描述 :省 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "省", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "省")]

        public string IiProvinceId { get; set; }

        /// <summary>
        /// 描述 :市 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "市", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "市")]

        public string IiCityId { get; set; }

        /// <summary>
        /// 描述 :县/区 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "县/区", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "县/区")]

        public string IiCountyId { get; set; }

        /// <summary>
        /// 描述 :镇 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "镇")]
        [ExcelColumn(Name = "镇")]

        public string IiTownId { get; set; }

        /// <summary>
        /// 描述 :村 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "村")]
        [ExcelColumn(Name = "村")]

        public string IiVillageId { get; set; }

        /// <summary>
        /// 描述 :地址 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "地址", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "地址")]

        public string IiAddress { get; set; }

        /// <summary>
        /// 描述 :英文地址 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "英文地址", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "英文地址")]

        public string IiEnAddress { get; set; }

        /// <summary>
        /// 描述 :网址 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "网址")]
        [ExcelColumn(Name = "网址")]

        public string IiWebSite { get; set; }

        /// <summary>
        /// 描述 :成立日期 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "成立日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "成立日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? IiFoundedTime { get; set; }

        /// <summary>
        /// 描述 :经营范围 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "经营范围", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "经营范围")]

        public string IiBusinessScope { get; set; }

        /// <summary>
        /// 描述 :母公司 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "母公司")]
        [ExcelColumn(Name = "母公司")]

        public string IiParentCorp { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "排序", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "排序")]

        public int IiSortCode { get; set; }

        /// <summary>
        /// 描述 :启用 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "启用", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "启用")]

        public int IiisEnabled { get; set; }

        /// <summary>
        /// 描述 :企业口号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "企业口号")]
        [ExcelColumn(Name = "企业口号")]

        public string IiSlogan { get; set; }

        /// <summary>
        /// 描述 :营业执照附件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "营业执照附件")]
        [ExcelColumn(Name = "营业执照附件")]

        public string IiLicenseAnnex { get; set; }

        /// <summary>
        /// 描述 :其它附件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "其它附件")]
        [ExcelColumn(Name = "其它附件")]

        public string IiOtherAnnex { get; set; }

        /// <summary>
        /// 描述 :自定义A 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义A")]
        [ExcelColumn(Name = "自定义A")]

        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :自定义B 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义B")]
        [ExcelColumn(Name = "自定义B")]

        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :自定义C 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义C")]
        [ExcelColumn(Name = "自定义C")]

        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :自定义D 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义D")]
        [ExcelColumn(Name = "自定义D")]

        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :自定义E 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义E")]
        [ExcelColumn(Name = "自定义E")]

        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :自定义F 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义F")]
        [ExcelColumn(Name = "自定义F")]

        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :自定义1 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义1", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义1")]

        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义2", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义2")]

        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义3", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义3")]

        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义4", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义4")]

        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义5", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义5")]

        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义6", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义6")]

        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]

        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]

        public int IsDeleted { get; set; }

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
    /// 机构信息
    /// 数据实体模板对象导出
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    [SugarTable("inst_info")]
    public class InstInfoImportTmpl
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "Guid", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "Guid")]
        public Guid IiGuid { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "语言", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "语言")]
        public string IiLangkey { get; set; }

        /// <summary>
        /// 描述 :编号 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false,ColumnDescription = "编号", ExtendedAttribute = ProteryConstant.NOTNULL)]

        [ExcelColumn(Name = "编号")]
        public string IiInstCode { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "类别", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "类别")]
        public string IiCategory { get; set; }

        /// <summary>
        /// 描述 :简称 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "简称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "简称")]
        public string IiShortName { get; set; }

        /// <summary>
        /// 描述 :全称 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "全称", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "全称")]
        public string IiFullName { get; set; }

        /// <summary>
        /// 描述 :性质 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "性质", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "性质")]
        public string IiNature { get; set; }

        /// <summary>
        /// 描述 :外线 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "外线", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "外线")]
        public string IiOuterPhone { get; set; }

        /// <summary>
        /// 描述 :内线 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "内线", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "内线")]
        public string IiInnerPhone { get; set; }

        /// <summary>
        /// 描述 :传真 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "传真", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "传真")]
        public string IiFax { get; set; }

        /// <summary>
        /// 描述 :邮编 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "邮编")]
        [ExcelColumn(Name = "邮编")]
        public string IiPostalcode { get; set; }

        /// <summary>
        /// 描述 :邮件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "邮件")]
        [ExcelColumn(Name = "邮件")]
        public string IiEmail { get; set; }

        /// <summary>
        /// 描述 :组织代码 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "组织代码", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "组织代码")]
        public string IiOrgCode { get; set; }

        /// <summary>
        /// 描述 :法人 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "法人", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "法人")]
        public string IiCorporate { get; set; }

        /// <summary>
        /// 描述 :地区 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "地区", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "地区")]
        public string IiRegionId { get; set; }

        /// <summary>
        /// 描述 :省 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "省", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "省")]
        public string IiProvinceId { get; set; }

        /// <summary>
        /// 描述 :市 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "市", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "市")]
        public string IiCityId { get; set; }

        /// <summary>
        /// 描述 :县/区 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "县/区", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "县/区")]
        public string IiCountyId { get; set; }

        /// <summary>
        /// 描述 :镇 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "镇")]
        [ExcelColumn(Name = "镇")]
        public string IiTownId { get; set; }

        /// <summary>
        /// 描述 :村 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "村")]
        [ExcelColumn(Name = "村")]
        public string IiVillageId { get; set; }

        /// <summary>
        /// 描述 :地址 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "地址", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "地址")]
        public string IiAddress { get; set; }

        /// <summary>
        /// 描述 :英文地址 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "英文地址", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "英文地址")]
        public string IiEnAddress { get; set; }

        /// <summary>
        /// 描述 :网址 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "网址")]
        [ExcelColumn(Name = "网址")]
        public string IiWebSite { get; set; }

        /// <summary>
        /// 描述 :成立日期 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "成立日期", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "成立日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? IiFoundedTime { get; set; }

        /// <summary>
        /// 描述 :经营范围 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "经营范围", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "经营范围")]
        public string IiBusinessScope { get; set; }

        /// <summary>
        /// 描述 :母公司 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "母公司")]
        [ExcelColumn(Name = "母公司")]
        public string IiParentCorp { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "排序", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "排序")]
        public int IiSortCode { get; set; }

        /// <summary>
        /// 描述 :启用 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "启用", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "启用")]
        public int IiisEnabled { get; set; }

        /// <summary>
        /// 描述 :企业口号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "企业口号")]
        [ExcelColumn(Name = "企业口号")]
        public string IiSlogan { get; set; }

        /// <summary>
        /// 描述 :营业执照附件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "营业执照附件")]
        [ExcelColumn(Name = "营业执照附件")]
        public string IiLicenseAnnex { get; set; }

        /// <summary>
        /// 描述 :其它附件 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "其它附件")]
        [ExcelColumn(Name = "其它附件")]
        public string IiOtherAnnex { get; set; }

        /// <summary>
        /// 描述 :自定义A 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义A")]
        [ExcelColumn(Name = "自定义A")]
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :自定义B 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义B")]
        [ExcelColumn(Name = "自定义B")]
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :自定义C 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义C")]
        [ExcelColumn(Name = "自定义C")]
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :自定义D 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义D")]
        [ExcelColumn(Name = "自定义D")]
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :自定义E 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义E")]
        [ExcelColumn(Name = "自定义E")]
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :自定义F 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义F")]
        [ExcelColumn(Name = "自定义F")]
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :自定义1 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义1", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义1")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :自定义2 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义2", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义2")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :自定义3 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义3", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义3")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :自定义4 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义4", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义4")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :自定义5 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义5", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义5")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :自定义6 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "自定义6", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "自定义6")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnDescription = "备注")]
        [ExcelColumn(Name = "备注")]
        public string ReMarks { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :false 
        /// </summary>
 	[SugarColumn(ColumnDescription = "软删除", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [ExcelColumn(Name = "软删除")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

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