﻿using SqlSugar;
using System;
using System.Linq;

namespace La.Model.System.Generate
{
    /// <summary>
    /// 代码生成表字段
    /// </summary>
    [SugarTable("gen_table_column")]
    [Tenant("0")]
    public class GenTableColumn : SysBase
    {
        /// <summary>
        /// 代码生成表列ID
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int ColumnId { get; set; }
        /// <summary>
        /// 导入代码生成表列名 首字母转了小写
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 代码生成表ID
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        public int TableId { get; set; }
        /// <summary>
        /// 代码生成表名称
        /// </summary>

        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        public string TableName { get; set; }
        /// <summary>
        /// 列说明
        /// </summary>
        //public string ColumnComment { get; set; } = string.Empty;
        private string columnComment;
        /// <summary>
        /// 列说明
        /// </summary>
        public string ColumnComment
        {
            get
            {
                return string.IsNullOrEmpty(columnComment) ? CsharpField : columnComment;
            }
            set
            {
                columnComment = value;
            }
        }
        /// <summary>
        /// 数据库列类型
        /// </summary>

        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        public string ColumnType { get; set; }
        /// <summary>
        /// C#类型
        /// </summary>
        public string CsharpType { get; set; }
        /// <summary>
        /// C# 字段名 首字母大写
        /// </summary>
        public string CsharpField { get; set; }
        /// <summary>
        /// 是否主键（1是）
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        public bool IsPk { get; set; }
        /// <summary>
        /// 是否必填（1是）
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// 是否自增（1是）
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        public bool IsIncrement { get; set; }
        /// <summary>
        /// 是否插入（1是）
        /// </summary>
        public bool IsInsert { get; set; }
        /// <summary>
        /// 是否需要编辑（1是）
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// 是否显示列表（1是）
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        /// 是否查询（1是）
        /// </summary>
        public bool IsQuery { get; set; }
        /// <summary>
        /// 是否排序（1是）
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否导出（1是）
        /// </summary>
        public bool IsExport { get; set; }
        /// <summary>
        /// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
        /// </summary>
        public string HtmlType { get; set; }
        /// <summary>
        /// 查询类型（等于、不等于、大于、小于、范围）
        /// </summary>
        public string QueryType { get; set; } = "EQ";
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; } = "";

        #region 额外字段
        /// <summary>
        /// 必填字串
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string RequiredStr
        {
            get
            {
                string[] arr = new string[] { "int", "long" };
                return (!IsRequired && HtmlType != "selectMulti" && (arr.Any(f => f.Contains(CsharpType))) || typeof(DateTime).Name == CsharpType) ? "?" : "";
            }
        }
        /// <summary>
        /// 前端排序字符串
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string SortStr
        {
            get
            {
                return IsSort ? " sortable" : "";
            }
        }
        /// <summary>
        /// C# 字段名 首字母小写，用于前端
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        //public string CsharpFieldFl { get; set; }
        public string CsharpFieldFl
        {
            get
            {
                return CsharpField[..1].ToLower() + CsharpField[1..];
            }
        }
        /// <summary>
        /// 前端 只读字段
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string DisabledStr
        {
            get
            {
                return (((!IsInsert && !IsEdit) || IsPk) && !IsRequired) ? " :disabled=\"true\"" : "";
            }
        }

        #endregion
    }
}
