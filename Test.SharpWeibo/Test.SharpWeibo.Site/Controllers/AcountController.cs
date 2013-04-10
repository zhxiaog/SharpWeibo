using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.SharpWeibo.Site.Models;

namespace Test.SharpWeibo.Site.Controllers
{
    public class AcountController : ApiController
    {
        static List<UserInfo> userInfos = new List<UserInfo>();
        static AcountController()
        {
            userInfos.Add(new UserInfo(){ NeckName="xaolo", UserName="zhxiaog", Password = "1" , UserId = "asdfg"});
            userInfos.Add(new UserInfo(){ NeckName="yemeng", UserName="guoyemeng", Password = "3" , UserId = "asasfdadfg"});

        }

        // GET api/acount
        [ActionName("Login")]
        public UserInfo GetLogin(string userName,string password)
        {
            var uu = userInfos.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            return uu;
        }

        // GET api/acount/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/acount
        public void Post([FromBody]string value)
        {
        }

        // PUT api/acount/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/acount/5
        public void Delete(int id)
        {
        }
    }
}
