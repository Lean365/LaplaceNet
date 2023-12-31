﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 客户信息查询对象
    /// </summary>
    public class SdClientQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 客户信息输入输出对象
    /// </summary>
    public class SdClientDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long ScId { get; set; }

        /// <summary>
        /// 描述 :销售组织 
        /// </summary>
        [Required(ErrorMessage = "销售组织不能为空")]

        [ExcelColumn(Name = "销售组织")]
        public string ScOrg { get; set; }

        /// <summary>
        /// 描述 :销售工厂 
        /// </summary>
        [Required(ErrorMessage = "销售工厂不能为空")]

        [ExcelColumn(Name = "销售工厂")]
        public string ScPlant { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// </summary>
        [Required(ErrorMessage = "行业类别不能为空")]

        [ExcelColumn(Name = "行业类别")]
        public string ScIndustryType { get; set; }

        /// <summary>
        /// 描述 :企业性质 
        /// </summary>
        [Required(ErrorMessage = "企业性质不能为空")]

        [ExcelColumn(Name = "企业性质")]
        public string ScEnterpriseNature { get; set; }

        /// <summary>
        /// 描述 :客户代码 
        /// </summary>
        [Required(ErrorMessage = "客户代码不能为空")]

        [ExcelColumn(Name = "客户代码")]
        public string ScCode { get; set; }

        /// <summary>
        /// 描述 :客户简称 
        /// </summary>
        [Required(ErrorMessage = "客户简称不能为空")]

        [ExcelColumn(Name = "客户简称")]
        public string ScAbbr { get; set; }

        /// <summary>
        /// 描述 :客户名称 
        /// </summary>
        [Required(ErrorMessage = "客户名称不能为空")]

        [ExcelColumn(Name = "客户名称")]
        public string ScName { get; set; }

        /// <summary>
        /// 描述 :企业法人 
        /// </summary>
        [Required(ErrorMessage = "企业法人不能为空")]

        [ExcelColumn(Name = "企业法人")]
        public string ScEbe { get; set; }

        /// <summary>
        /// 描述 :营业执照 
        /// </summary>
        [Required(ErrorMessage = "营业执照不能为空")]

        [ExcelColumn(Name = "营业执照")]
        public string ScBusinessNo { get; set; }

        /// <summary>
        /// 描述 :税号 
        /// </summary>
        [Required(ErrorMessage = "税号不能为空")]

        [ExcelColumn(Name = "税号")]
        public string ScTaxNo { get; set; }

        /// <summary>
        /// 描述 :税别 
        /// </summary>
        [Required(ErrorMessage = "税别不能为空")]

        [ExcelColumn(Name = "税别")]
        public string ScTaxType { get; set; }

        /// <summary>
        /// 描述 :主营业务 
        /// </summary>
        [Required(ErrorMessage = "主营业务不能为空")]

        [ExcelColumn(Name = "主营业务")]
        public string ScMainBusiness { get; set; }

        /// <summary>
        /// 描述 :交易币种 
        /// </summary>
        [Required(ErrorMessage = "交易币种不能为空")]

        [ExcelColumn(Name = "交易币种")]
        public string ScCcy { get; set; }

        /// <summary>
        /// 描述 :付款条件 
        /// </summary>
        [Required(ErrorMessage = "付款条件不能为空")]

        [ExcelColumn(Name = "付款条件")]
        public string ScPayTerms { get; set; }

        /// <summary>
        /// 描述 :付款方式 
        /// </summary>
        [Required(ErrorMessage = "付款方式不能为空")]

        [ExcelColumn(Name = "付款方式")]
        public string ScPayMethod { get; set; }

        /// <summary>
        /// 描述 :统驭科目 
        /// </summary>
        [Required(ErrorMessage = "统驭科目不能为空")]

        [ExcelColumn(Name = "统驭科目")]
        public string ScRecAccount { get; set; }

        /// <summary>
        /// 描述 :贸易条件 
        /// </summary>
        [Required(ErrorMessage = "贸易条件不能为空")]

        [ExcelColumn(Name = "贸易条件")]
        public string ScTradeTerms { get; set; }

        /// <summary>
        /// 描述 :装运条件 
        /// </summary>
        [Required(ErrorMessage = "装运条件不能为空")]

        [ExcelColumn(Name = "装运条件")]
        public string ScShippingTerms { get; set; }

        /// <summary>
        /// 描述 :客户等级 
        /// </summary>

        [ExcelColumn(Name = "客户等级")]
        public string ScCustomerGrade { get; set; }

        /// <summary>
        /// 描述 :客户信用 
        /// </summary>

        [ExcelColumn(Name = "客户信用")]
        public string ScCustomerCredit { get; set; }

        /// <summary>
        /// 描述 :首次交易 
        /// </summary>

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? ScFirstTransDate { get; set; }

        /// <summary>
        /// 描述 :最近交易 
        /// </summary>

        [ExcelColumn(Name = "最近交易", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? ScLastTransDate { get; set; }

        /// <summary>
        /// 描述 :银行代码 
        /// </summary>
        [Required(ErrorMessage = "银行代码不能为空")]

        [ExcelColumn(Name = "银行代码")]
        public string ScBankCode { get; set; }

        /// <summary>
        /// 描述 :银行名称 
        /// </summary>
        [Required(ErrorMessage = "银行名称不能为空")]

        [ExcelColumn(Name = "银行名称")]
        public string ScBankName { get; set; }

        /// <summary>
        /// 描述 :分行名称 
        /// </summary>

        [ExcelColumn(Name = "分行名称")]
        public string ScBranchName { get; set; }

        /// <summary>
        /// 描述 :银行所在国 
        /// </summary>
        [Required(ErrorMessage = "银行所在国不能为空")]

        [ExcelColumn(Name = "银行所在国")]
        public string ScBankCountry { get; set; }

        /// <summary>
        /// 描述 :银行所在州省 
        /// </summary>
        [Required(ErrorMessage = "银行所在州省不能为空")]

        [ExcelColumn(Name = "银行所在州省")]
        public string ScBankState { get; set; }

        /// <summary>
        /// 描述 :银行所在市 
        /// </summary>
        [Required(ErrorMessage = "银行所在市不能为空")]

        [ExcelColumn(Name = "银行所在市")]
        public string ScBankCity { get; set; }

        /// <summary>
        /// 描述 :银行所在县 
        /// </summary>
        [Required(ErrorMessage = "银行所在县不能为空")]

        [ExcelColumn(Name = "银行所在县")]
        public string ScBankCounty { get; set; }

        /// <summary>
        /// 描述 :银行地址 
        /// </summary>
        [Required(ErrorMessage = "银行地址不能为空")]

        [ExcelColumn(Name = "银行地址")]
        public string ScBankAddr { get; set; }

        /// <summary>
        /// 描述 :银行地址1 
        /// </summary>

        [ExcelColumn(Name = "银行地址1")]
        public string ScBankAddr1 { get; set; }

        /// <summary>
        /// 描述 :银行地址2 
        /// </summary>

        [ExcelColumn(Name = "银行地址2")]
        public string ScBankAddr2 { get; set; }

        /// <summary>
        /// 描述 :银行账号 
        /// </summary>
        [Required(ErrorMessage = "银行账号不能为空")]

        [ExcelColumn(Name = "银行账号")]
        public string ScBankAccount { get; set; }

        /// <summary>
        /// 描述 :SWIFT代码 
        /// </summary>

        [ExcelColumn(Name = "SWIFT代码")]
        public string ScBankSwiftNo { get; set; }

        /// <summary>
        /// 描述 :国家地区 
        /// </summary>

        [ExcelColumn(Name = "国家地区")]
        public string ScRegionCode { get; set; }

        /// <summary>
        /// 描述 :州省 
        /// </summary>

        [ExcelColumn(Name = "州省")]
        public string ScState { get; set; }

        /// <summary>
        /// 描述 :市 
        /// </summary>

        [ExcelColumn(Name = "市")]
        public string ScCity { get; set; }

        /// <summary>
        /// 描述 :县 
        /// </summary>

        [ExcelColumn(Name = "县")]
        public string ScCounty { get; set; }

        /// <summary>
        /// 描述 :地址 
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]

        [ExcelColumn(Name = "地址")]
        public string ScAddr { get; set; }

        /// <summary>
        /// 描述 :地址1 
        /// </summary>

        [ExcelColumn(Name = "地址1")]
        public string ScAddr1 { get; set; }

        /// <summary>
        /// 描述 :地址2 
        /// </summary>

        [ExcelColumn(Name = "地址2")]
        public string ScAddr2 { get; set; }

        /// <summary>
        /// 描述 :联系人 
        /// </summary>

        [ExcelColumn(Name = "联系人")]
        public string ScContacts { get; set; }

        /// <summary>
        /// 描述 :电邮 
        /// </summary>

        [ExcelColumn(Name = "电邮")]
        public string ScEmail { get; set; }

        /// <summary>
        /// 描述 :电话 
        /// </summary>

        [ExcelColumn(Name = "电话")]
        public string ScTelNo { get; set; }

        /// <summary>
        /// 描述 :传真 
        /// </summary>

        [ExcelColumn(Name = "传真")]
        public string ScFaxNp { get; set; }

        /// <summary>
        /// 描述 :手机 
        /// </summary>

        [ExcelColumn(Name = "手机")]
        public string ScPhoneNo { get; set; }

        /// <summary>
        /// 描述 :冻结标记 
        /// </summary>
        [Required(ErrorMessage = "冻结标记不能为空")]

        [ExcelColumn(Name = "冻结标记")]
        public bool IsFroze { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF01")]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF02")]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF03")]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF04")]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF05")]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UDF06")]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF51")]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF52")]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF53")]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF54")]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF55")]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF56")]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]

        [ExcelColumn(Name = "软删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "CreateBy")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "CreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "UpdateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }



    }
}