using System;
using System.Collections.Generic;
using System.Text;
using La.Model.System;
using La.Repository;

namespace La.Service.System.IService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);
        string CheckPostCodeUnique(SysPost sysPost);
        List<SysPost> GetAll();
    }
}
