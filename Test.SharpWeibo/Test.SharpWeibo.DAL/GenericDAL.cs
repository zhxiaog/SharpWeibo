using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using NHibernate;
using NHibernate.Linq;
namespace Test.SharpWeibo.DAL
{
    public class GenericDAL<T>
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region 属性
        //[ThreadStatic]
        private ISession _session;

        public ISession Session
        {
            get 
            {
                if (_session == null)
                    _session = NHHelper.GetSession();
                return _session; 
            }
            set { _session = value; }
        }

        private IStatelessSession _statelessSession = null;
        /// <summary>
        /// 静态session，没有缓存
        /// </summary>
        public IStatelessSession StatelessSession
        {
            get 
            {
                if (_statelessSession == null)
                    _statelessSession = NHHelper.GetStatelessSession();
                return _statelessSession;
            }
            set
            {
                _statelessSession = value;
            }
        }

        private bool statelessMode = false;
        /// <summary>
        /// 标志使用静态session还是常规session
        /// </summary>
        public bool StatelessMode
        {
            get 
            {
                return statelessMode; 
            }
            set 
            { 
                statelessMode = value;
            }
        }
        #endregion

        #region 构造/析构函数
        public GenericDAL()
        {
        }

        public GenericDAL(ISession session)
        {
            _session = session;
        }

        public GenericDAL(bool useStatelessSession)
        {
            this.StatelessMode = useStatelessSession;
        }

        public GenericDAL(IStatelessSession session)
        {
            this.StatelessMode = true;
            this.StatelessSession = session;
        }

        ~GenericDAL()
        {
            if (_session != null && _session.IsOpen)
            {
                try
                {
                    NHHelper.CloseSession(_session);
                }
                catch (Exception ex)
                {
                    if(logger != null)
                        logger.Warn("DAL没有正确关闭连接:" + typeof(T).FullName, ex);
                }
            }

            if (_statelessSession != null && _statelessSession.IsOpen)
            {
                try
                {
                    NHHelper.CloseStatelessSession(_statelessSession);
                }
                catch (Exception ex)
                {
                    if (logger != null)
                        logger.Warn("DAL没有正确关闭连接:" + typeof(T).FullName, ex);
                }
            }
        }
        #endregion

        /// <summary>
        /// 提供接口进行强制保存
        /// </summary>
        public void Flush()
        {
            if (!statelessMode && _session != null)
            {
                try
                {
                    _session.Flush();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public T Get(int id)
        {
            T t;
            if (statelessMode)
                t = StatelessSession.Get<T>(id);
            else
                t = Session.Get<T>(id);
            return t;
        }

        public T Create(T Tobj)
        {
            object t = null;

            if (statelessMode)
                t = StatelessSession.Insert(Tobj);
            else
                t = Session.Save(Tobj);
            return Tobj;
        }
        public T Update(T Tobj)
        {
            if (statelessMode)
                StatelessSession.Update(Tobj);
            else
                Session.Update(Tobj);
            return Tobj;
        }

        public void Delete(T Tobj)
        {
            if (statelessMode)
                StatelessSession.Delete(Tobj);
            else
                Session.Delete(Tobj);
        }
    }
}
