using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using eUseControl.Domain;
using Domain.Enums;
using Domain.Entities.User;
using System.Data.Entity;

namespace BusinessLogic.DBModel
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
