using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.SharpWeibo.Entities;
using Test.SharpWeibo.Biz;
using Test.SharpWeibo.IBL;

namespace Test.SharpWeibo.Site2.Controllers.api
{
    public class UserController : ApiController
    {
        IUserService service = BusinessServiceFactory.GetUserService();
        // GET api/user
        public IEnumerable<UserInfo> Get()
        {
            return service.GetAll();
        }

        // GET api/user/5
        public UserInfo Get(string userID)
        {
            return service.Get(userID);
        }

        // POST api/user
        public void Post([FromBody]UserInfo value)
        {
            service.Create(value);
        }

        //TODO:实现人员更新
        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        //TODO:实现删除
        // DELETE api/user/5
        public void Delete(string userID)
        {
        }
    }
}
