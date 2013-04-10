using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.Entities;
using NHibernate.Linq;
namespace Test.SharpWeibo.DAL
{
    public class UserInfoDAL : GenericDAL<UserInfo>
    {
        public List<UserInfo> GetAll()
        {
            return this.Session.Query<UserInfo>().ToList();
        }

        public UserInfo Get(string userId)
        {
            return this.Session.Query<UserInfo>().Where(u => u.UserID == userId).FirstOrDefault();
        }

        public UserInfo Get(string userName, string password)
        {
            return this.Session.Query<UserInfo>().Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
        }

        public List<UserInfo> GetAll2()
        {
            var list = new List<UserInfo>();
            list.Add(new UserInfo() { CreateDate = DateTime.Now, Email = "zhxiaogg@gmal.com", Gender = 1, NeckName = "zhxiaog", UserName = "zhxiaog", Password = "1", UserID = "zhxiaog", LastActiveDate = DateTime.Now });
            return list;
        }
    }
}
