using System.Collections.Generic;
using La.Model;
using La.Model.System;
using La.Model.System.Dto;

namespace La.Service.System.IService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author Lean365
    /// @date 2021-12-15
    /// </summary>
    public interface ISysNoticeService : IBaseService<SysNotice>
    {
        List<SysNotice> GetSysNotices();

        PagedInfo<SysNotice> GetPageList(SysNoticeQueryDto parm);
    }
}
