using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.IBL;

namespace Test.SharpWeibo.Biz
{
    public class BusinessServiceFactory
    {
        public static IWeiboService GetWeiboService()
        {
            return new WeiboService();
        }

        public static IUserService GetUserService()
        {
            return new UserInfoService();
        }
    }
}
