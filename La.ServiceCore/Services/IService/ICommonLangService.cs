using La.Model;
using La.Model.Dto;
using La.Model.Models;

namespace La.Service.System.IService
{
    /// <summary>
    /// 多语言配置service接口
    ///
    /// @author Lean365
    /// @date 2022-05-06
    /// </summary>
    public interface ICommonLangService : IBaseService<CommonLang>
    {
        PagedInfo<CommonLang> GetList(CommonLangQueryDto parm);
        List<CommonLang> GetLangList(CommonLangQueryDto parm);
        dynamic GetListToPivot(CommonLangQueryDto parm);
        void StorageCommonLang(CommonLangDto parm);
        Dictionary<string, object> SetLang(List<CommonLang> msgList);


        (string, object, object) ImportCommonLang(List<CommonLang> list);
    }
}
