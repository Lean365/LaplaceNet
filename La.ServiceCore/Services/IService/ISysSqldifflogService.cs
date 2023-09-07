using La.Model;
using La.Model.System;
using La.Model.System.Dto;

namespace La.Service.System.IService
{
    /// <summary>
    /// 数据差异日志service接口
    /// </summary>
    public interface ISysSqldifflogService : IBaseService<SysSqldifflog>
    {
        PagedInfo<SysSqldifflogDto> GetList(SysSqldifflogQueryDto parm);

        SysSqldifflog GetInfo(long PId);

        SysSqldifflog AddSysSqldifflog(SysSqldifflog parm);

        int UpdateSysSqldifflog(SysSqldifflog parm);

    }
}
