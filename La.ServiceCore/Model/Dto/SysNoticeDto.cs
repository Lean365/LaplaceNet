using System.ComponentModel.DataAnnotations;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 通知公告表输入对象
    /// </summary>
    public class SysNoticeDto
    {
        public int NoticeId { get; set; }
        [Required]
        public string NoticeTitle { get; set; }
        public int NoticeType { get; set; }
        public string NoticeContent { get; set; }
        public int IsStatus { get; set; }
        public string ReMarks { get; set; }
    }

    /// <summary>
    /// 通知公告表查询对象
    /// </summary>
    public class SysNoticeQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsStatus { get; set; }
    }
}
