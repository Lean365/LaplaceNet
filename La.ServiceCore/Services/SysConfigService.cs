using La.Infra.Attribute;
using La.Model.System;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 参数配置Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISysConfigService), ServiceLifetime = LifeTime.Transient)]
    public class SysConfigService : BaseService<SysConfig>, ISysConfigService
    {
        #region 业务逻辑代码

        public SysConfig GetSysConfigByKey(string key)
        {
            return Queryable().First(f => f.ConfigKey == key);
        }

        #endregion
    }
}