using System.Data.Entity;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
     class UserContext : DbContext
    {
        public UserContext() :
            base("name=eUseControl") //connectionstring name define in
        { 
        }

        public virtual DbSet<UDbTable> Users { get; set; }


    }
}
