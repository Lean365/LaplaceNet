﻿using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 文件存储输入对象
    /// </summary>
    public class SysFileDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 文件原名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 描述 : 存储文件名
        /// 空值 : true  
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 描述 : 文件存储地址 eg：/uploads/20220202
        /// 空值 : true  
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 描述 : 仓库位置 eg：/uploads
        /// 空值 : true  
        /// </summary>
        public string StorePath { get; set; }
        /// <summary>
        /// 描述 : 文件大小
        /// 空值 : true  
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 描述 : 文件扩展名
        /// 空值 : true  
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 描述 : 创建人
        /// 空值 : true  
        /// </summary>
        public string Create_by { get; set; }
        /// <summary>
        /// 描述 : 上传时间
        /// 空值 : true  
        /// </summary>
        public DateTime? Create_time { get; set; }
        /// <summary>
        /// 描述 : 存储类型
        /// 空值 : true  
        /// </summary>
        public int? StoreType { get; set; }
        /// <summary>
        /// 描述 : 访问路径
        /// 空值 : true  
        /// </summary>
        public string AccessUrl { get; set; }
        /// <summary>
        /// 文件输入
        /// </summary>
        public SysFileDto() { }
        /// <summary>
        /// 文件输入
        /// </summary>
        /// <param name="originFileName"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="fileSize"></param>
        /// <param name="storePath"></param>
        /// <param name="accessUrl"></param>
        /// <param name="create_by"></param>
        public SysFileDto(string originFileName, string fileName, string ext, string fileSize, string storePath, string accessUrl, string create_by)
        {
            StorePath = storePath;
            RealName = originFileName;
            FileName = fileName;
            FileExt = ext;
            FileSize = fileSize;
            AccessUrl = accessUrl;
            Create_by = create_by;
            Create_time = DateTime.Now;
        }
    }
    /// <summary>
    /// 文件查询输入
    /// </summary>
    public class SysFileQueryDto : PagerInfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? BeginCreate_time { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndCreate_time { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int? StoreType { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public long? FileId { get; set; }
    }
}
