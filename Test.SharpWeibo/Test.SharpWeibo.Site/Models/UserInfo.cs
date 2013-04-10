using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.SharpWeibo.Site.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string NeckName { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        private string _userid { get; set; }
    }
}