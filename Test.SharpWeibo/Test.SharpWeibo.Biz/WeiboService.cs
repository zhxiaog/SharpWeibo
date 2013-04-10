using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.IBL;
using Test.SharpWeibo.DAL;
using Test.SharpWeibo.Entities;

namespace Test.SharpWeibo.Biz
{
    public class WeiboService:IWeiboService
    {
        
        public List<Entities.WeiboMsg> GetAll()
        {
            WeiboDAL dal = new WeiboDAL();
            return dal.GetAll();
        }

        public List<Entities.WeiboMsg> GetUserMsgs(string userID)
        {
            WeiboDAL dal = new WeiboDAL();
            return dal.Get(userID);
        }

        public Entities.WeiboMsg Publish(Entities.WeiboMsg msg)
        {
            WeiboDAL dal = new WeiboDAL();
            WeiboMsg weiboMsg = dal.Create(msg);
            dal.Flush();
            return weiboMsg;
        }

        public bool Delete(Entities.WeiboMsg msg)
        {
            WeiboDAL dal = new WeiboDAL();
            dal.Delete(msg);
            dal.Flush();
            return true;
        }


        public WeiboMsg Get(int Id)
        {
            WeiboDAL dal = new WeiboDAL();
            return dal.Get(Id);
        }
    }
}
