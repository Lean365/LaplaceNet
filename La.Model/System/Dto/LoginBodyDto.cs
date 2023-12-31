﻿using System.ComponentModel.DataAnnotations;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 登入输入
    /// </summary>
    public class LoginBodyDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

        /**
         * 验证码
         */
        public string Code { get; set; }

        /**
         * 唯一标识
         */
        public string Uuid { get; set; } = "";
        /// <summary>
        /// 登入IP
        /// </summary>
        public string LoginIP { get; set; }
    }
}
