using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Test.SharpWeibo.DAL
{
    public sealed class NHHelper
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ISessionFactory sessionFactory;
        private static readonly Configuration nhConfiguration;
        static NHHelper()
        {
            try
            {
                nhConfiguration = new Configuration().Configure();
                sessionFactory = nhConfiguration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.Error(string.Format("NHibernate初始化报错:{0}", ex.Message), ex);
                }
                throw (ex);
            }
        }

        public static ISession GetSession()
        {
            ISession session = sessionFactory.OpenSession();
            return session;
        }

        public static IStatelessSession GetStatelessSession()
        {
            IStatelessSession session = sessionFactory.OpenStatelessSession();
            return session;
            
        }

        public static void CloseSession(ISession session)
        {
            session.Flush();    //Session在Close的时候会Flush，但还不确定
            session.Close();
        }

        public static void CloseStatelessSession(IStatelessSession session)
        {
            session.Close();
        }

        public static void CloseFactory()
        {
            if (sessionFactory != null && !sessionFactory.IsClosed)
                sessionFactory.Close();
        }

        public static void CreateDBSchemas()
        {
            try
            {
                SchemaExport se = new SchemaExport(nhConfiguration);
                se.Create(true, true);
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.Error(string.Format("NHibernate构建数据库结构报错:{0}", ex.Message), ex);
                }

                throw ex;
            }
        }
    }
}
