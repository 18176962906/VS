using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Login
    {
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.UserName + "-" + this.Password;
        }


    }
}