

namespace La.CodeGenerator
{
    /// <summary>
    /// 代码生成常量
    /// </summary>
    public class GenConstants
    {
        public static string Gen_dbname = "CodeGenDbConfig:DbName";
        public static string Gen_author = "gen:author";
        public static string Gen_autoPre = "gen:autoPre";
        public static string Gen_tablePrefix = "gen:tablePrefix";

        /// <summary>
        /// InputDto输入实体是不包含字段
        /// </summary>
        public static readonly string[] inputDtoNoField = new string[] { "createTime", "updateTime", "addtime", "create_time", "update_time", "create_by", "update_by", "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56" };
        /// <summary>
        /// 图片字段
        /// </summary>
        public static readonly string[] imageFiled = new string[] { "icon", "img", "image", "url", "pic", "photo", "avatar" };
        /// <summary>
        /// 下拉框字段
        /// </summary>
        public static readonly string[] selectFiled = new string[] { "IsStatus", "type", "state", "sex", "gender" };
        /// <summary>
        /// 单选按钮字段
        /// </summary>
        public static readonly string[] radioFiled = new string[] { "IsStatus", "state", "is" };

        /// <summary>
        /// 单表（增删改查）
        /// </summary>
        public static string TPL_CRUD = "crud";

        /// <summary>
        /// 树表（增删改查）
        /// </summary>
        public static string TPL_TREE = "tree";

        /// <summary>
        /// 主子表（增删改查）
        /// </summary>
        public static string TPL_SUB = "sub";

        /// <summary>
        /// 树编码字段
        /// </summary>
        public static string TREE_CODE = "treeCode";

        /// <summary>
        /// 树父编码字段
        /// </summary>
        public static string TREE_PARENT_CODE = "treeParentCode";

        /// <summary>
        /// 树名称字段
        /// </summary>
        public static string TREE_NAME = "treeName";

        /// <summary>
        /// 上级菜单ID字段
        /// </summary>
        public static string PARENT_MENU_ID = "parentMenuId";

        /// <summary>
        /// 上级菜单名称字段
        /// </summary>
        public static string PARENT_MENU_NAME = "parentMenuName";

        /// <summary>
        /// 数据库字符串类型
        /// </summary>
        public static string[] COLUMNTYPE_STR = { "char", "varchar", "nvarchar", "varchar2" };

        /// <summary>
        /// 数据库文本类型
        /// </summary>
        public static string[] COLUMNTYPE_TEXT = { "tinytext", "text", "mediumtext", "longtext" };

        /// <summary>
        /// 数据库时间类型
        /// </summary>
        public static string[] COLUMNTYPE_TIME = { "datetime", "time", "date", "timestamp" };

        /// <summary>
        /// 页面不需要编辑字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_EDIT = { "id", "create_by", "create_time", "IsDeleted", "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56" };

        /// <summary>
        /// 页面不需要显示的列表字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_LIST = { "IsDeleted", "update_by", "update_time", "password", "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56" };

        /// <summary>
        /// 页面不需要查询字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_QUERY = { "id", "create_by", "create_time", "IsDeleted", "update_by", "update_time", "Remark", "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56" };

        /// <summary>
        /// 页面不需要导出字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_EXPORT = { "update_by", "update_time", "IsDeleted", "UDF01", "UDF51", "UDF02", "UDF52", "UDF03", "UDF53", "UDF04", "UDF54", "UDF05", "UDF55", "UDF06", "UDF56" };
        /// <summary>
        /// 页面不需要填写字段
        /// </summary>

        public static string[] COLUMNNAME_NOT_REQUIRED = { "IsDeleted", "UDF01", "UDF51", "UDF02", "UDF52", "UDF03", "UDF53", "UDF04", "UDF54", "UDF05", "UDF55", "UDF06", "UDF56" };

        /// <summary>
        /// Entity基类字段
        /// </summary>
        public static string[] BASE_ENTITY = { "createBy", "createTime", "updateBy", "updateTime", "ReMarks" };

        /// <summary>
        /// Tree基类字段
        /// </summary>
        public static string[] TREE_ENTITY = { "parentName", "parentId", "orderNum", "ancestors", "children" };

        /// <summary>
        /// 文本框
        /// </summary>
        public static string HTML_INPUT = "input";
        /// <summary>
        /// 数字框
        /// </summary>
        public static string HTML_INPUT_NUMBER = "inputNumber";

        /// <summary>
        /// 文本域
        /// </summary>
        public static string HTML_TEXTAREA = "textarea";

        /** 下拉框 */
        public static string HTML_SELECT = "select";
        /// <summary>
        /// 下拉多选
        /// </summary>
        public static string HTML_SELECT_MULTI = "selectMulti";
        /// <summary>
        /// 下拉远程
        /// </summary>
        public static string HTML_SELECT_REMOTE = "SelectRemote";

        /// <summary>
        /// 单选框
        /// </summary>
        public static string HTML_RADIO = "radio";

        /// <summary>
        /// 复选框
        /// </summary>
        public static string HTML_CHECKBOX = "checkbox";

        /// <summary>
        /// 日期控件
        /// </summary>
        public static string HTML_DATETIME = "datetime";

        /// <summary>
        /// 图片上传控件
        /// </summary>
        public static string HTML_IMAGE_UPLOAD = "imageUpload";

        /// <summary>
        /// 文件上传控件
        /// </summary>
        public static string HTML_FILE_UPLOAD = "fileUpload";

        /// <summary>
        /// 富文本控件
        /// </summary>
        public static string HTML_EDITOR = "editor";
        /// <summary>
        /// 自定义输入框
        /// </summary>
        public static string HTML_CUSTOM_INPUT = "customInput";
        /// <summary>
        /// 颜色选择器
        /// </summary>
        public static string HTML_COLORPICKER = "colorPicker";

        /// <summary>
        /// 模糊查询
        /// </summary>
        public static string QUERY_LIKE = "LIKE";

        /// <summary>
        /// 需要
        /// </summary>
        public static string REQUIRE = "1";
        /// <summary>
        /// 时间类型
        /// </summary>
        public static string TYPE_DATE = "DateTime";
    }
}