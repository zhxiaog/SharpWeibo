using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.SharpWeibo.Entities;
using Test.SharpWeibo.IBL;
using Test.SharpWeibo.Biz;

namespace Test.SharpWeibo.Site2.Controllers.api
{
    public class MessagesController : ApiController
    {
        // GET api/messages
        static IWeiboService service = BusinessServiceFactory.GetWeiboService();
        public IEnumerable<WeiboMsg> Get()
        {
            return service.GetAll();
        }

        // GET api/messages/5
        public WeiboMsg Get(int id)
        {
            return service.Get(id);
        }

        [ActionName("usermsg")]
        public IEnumerable<WeiboMsg> Get(string UserId)
        {
            return service.GetUserMsgs(UserId);
        }
        // POST api/messages
        public void Post([FromBody]WeiboMsg value)
        {
            service.Publish(value);
        }

        // PUT api/messages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/messages/5
        public void Delete(int id)
        {
            var msg = service.Get(id);
            if (msg == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            service.Delete(msg);
        }
    }
}
