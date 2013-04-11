using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.IBL;
using Test.SharpWeibo.DAL;
using Test.SharpWeibo.Entities;

namespace Test.SharpWeibo.Biz
{
    public class UserInfoService:IUserService
    {

        public List<Entities.UserInfo> GetAll()
        {
            UserInfoDAL dal = new UserInfoDAL();
            var list = dal.GetAll();
            return list;
        }

        public Entities.UserInfo Get(string userID)
        {
            UserInfoDAL dal = new UserInfoDAL();
            UserInfo userInfo = dal.Get(userID);
            return userInfo;
        }

        public Entities.UserInfo Create(Entities.UserInfo user)
        {
            user.CreateDate = DateTime.Now;
            user.LastActiveDate = DateTime.Now;
            UserInfoDAL dal = new UserInfoDAL();
            var userInfo = dal.Create(user);
            dal.Flush();
            return userInfo;
        }

        public Entities.UserInfo Login(string UserName, string password)
        {
            UserInfoDAL dal = new UserInfoDAL();
            UserInfo userInfo = dal.Get(UserName, password);
            return userInfo;
        }


        public bool Delete(UserInfo user)
        {
            UserInfoDAL dal = new UserInfoDAL();
            dal.Delete(user);
            dal.Flush();
            return true;
        }
    }
}
