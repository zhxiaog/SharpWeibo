using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.Entities;

namespace Test.SharpWeibo.IBL
{
    public interface IUserService
    {
        List<UserInfo> GetAll();
        UserInfo Get(string userID);
        UserInfo Create(UserInfo user);
        bool Delete(UserInfo user);
        UserInfo Login(string UserName, string password);
    }
}
