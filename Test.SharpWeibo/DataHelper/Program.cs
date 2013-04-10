using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.SharpWeibo.DAL;
using Test.SharpWeibo.Biz;

namespace DataHelper
{
    class Program
    {

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            try
            {
                NHHelper.CreateDBSchemas();
                Console.WriteLine("创建数据结构OK");
                CreateDate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void CreateDate()
        {
            var searvice = new WeiboService();
            var dal = new WeiboDAL();
            var list = dal.GetAll2();
            foreach (var weiboMsg in list)
            {
                searvice.Publish(weiboMsg);
            }

            var searvice3 = new UserInfoService();
            var dal3 = new UserInfoDAL(); ;
            var list3 = dal3.GetAll2();
            foreach (var userInfo in list3)
            {
                searvice3.Create(userInfo);
            }

            Console.WriteLine("数据导入完成");
        }
    }
}
