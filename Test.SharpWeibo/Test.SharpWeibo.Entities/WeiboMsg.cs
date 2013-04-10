using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.SharpWeibo.Entities
{
    public class WeiboMsg
    {
        public virtual int ID { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual string userID { get; set; }
    }
}
