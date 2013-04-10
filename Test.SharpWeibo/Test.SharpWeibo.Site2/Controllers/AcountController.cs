using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.SharpWeibo.IBL;
using Test.SharpWeibo.Biz;
using Test.SharpWeibo.Entities;

namespace Test.SharpWeibo.Site2.Controllers
{
    public class AcountController : ApiController
    {
        static IUserService service = BusinessServiceFactory.GetUserService();
        // GET api/acount
        [ActionName("Login")]
        public UserInfo GetLogin(string userName,string password)
        {
            var uu = service.Login(userName, password);
            return uu;
        }
    }
}
