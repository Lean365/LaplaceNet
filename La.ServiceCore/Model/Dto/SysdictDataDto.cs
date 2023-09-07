using System.Collections.Generic;

namespace La.Model.System.Dto
{
    public class SysdictDataDto
    {
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMarks { get; set; }
        public List<SysDictData> List { get; set; }
    }
}
