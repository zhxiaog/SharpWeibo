using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.Entities;

namespace Test.SharpWeibo.IBL
{
    public interface IWeiboService
    {
        List<WeiboMsg> GetAll();
        List<WeiboMsg> GetUserMsgs(string userID);
        WeiboMsg Publish(WeiboMsg msg);
        bool Delete(WeiboMsg msg);
        WeiboMsg Get(int Id);
    }
}
