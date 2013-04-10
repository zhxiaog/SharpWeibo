using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.Entities;
using NHibernate.Linq;
namespace Test.SharpWeibo.DAL
{
    public class WeiboDAL:GenericDAL<WeiboMsg>
    {
        public List<WeiboMsg> GetAll()
        {
            return this.Session.Query<WeiboMsg>().ToList();
        }

        public List<WeiboMsg> Get(string userID)
        {
            return this.Session.Query<WeiboMsg>().Where(w => w.userID == userID).ToList();
        }

        public WeiboMsg Get(int id)
        {
            return this.Session.Query<WeiboMsg>().Where(w => w.ID == id).FirstOrDefault();
        }

        public List<WeiboMsg> GetAll2()
        {
            var list = new List<WeiboMsg>();
            list.Add(new WeiboMsg() { Content = "hello,weibo!", PublishDate = DateTime.Now, userID = "zhxiaog" });
            return list;
        }
    }
}
