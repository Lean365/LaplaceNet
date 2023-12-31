﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 用户注册输入
    /// </summary>
    public class RegisterDto
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
        /// <summary>
        /// 密码确认
        /// </summary>
        [Required(ErrorMessage = "确认密码不能为空")]
        public string ConfirmPassword { get; set; }
        /**
         * 验证码
         */
        public string Code { get; set; }

        /**
         * 唯一标识
         */
        public string Uuid { get; set; } = "";
    }
}
