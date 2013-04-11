using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.SharpWeibo.Entities
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.CreateDate = DateTime.Now;
            this.LastActiveDate = DateTime.Now;
        }

        public virtual int ID { get; set; }
        public virtual string UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string NeckName { get; set; }
        public virtual int Gender { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastActiveDate { get; set; }
    }
}
