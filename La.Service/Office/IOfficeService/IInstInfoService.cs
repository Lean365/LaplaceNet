using System;
using La.Model;
using La.Model.Dto;
using La.Model.Office;
using System.Collections.Generic;

namespace La.Service.Office.IOfficeService
{
    /// <summary>
    /// 机构信息
    /// service接口
    /// @author Lean365
    /// @date 2023-09-07
    /// </summary>
    public interface IInstInfoService : IBaseService<InstInfo>
    {
        /// <summary>
        /// 机构信息
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstInfoDto> GetList(InstInfoQueryDto parm);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string entryString);

        /// <summary>
        /// 机构信息
        /// 详情
        /// </summary>
        /// <param name="IiGuid"></param>
        /// <returns></returns>

        InstInfo GetInfo(Guid IiGuid);

        /// <summary>
        /// 机构信息
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstInfo AddInstInfo(InstInfo parm);

        /// <summary>
        /// 机构信息
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstInfo(InstInfo parm);

        /// <summary>
        /// 导入
        /// 机构信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstInfo(List<InstInfo> list);
    }
}
