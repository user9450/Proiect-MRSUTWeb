using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel
{
     public class SessionContext : DBContext
     {

          public SessionContext() : base("name=CCToolShop")
          {
          }

          public virutal DbSet<Session> Sessions { get; set; }
     }
}
