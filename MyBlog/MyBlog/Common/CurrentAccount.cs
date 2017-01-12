using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using MyBlog.Model;

namespace MyBlog.Common
{
    public sealed class CurrentAccount
    {
        /// <summary>
        /// 不能删除
        /// </summary>
        private CurrentAccount()
        {

        }


        /// <summary>
        /// 当前登录帐号
        /// </summary>
        public static Account Account
        {
            get
            {
                return (Account)CallContext.GetData("Account");
            }
        }
    }
}