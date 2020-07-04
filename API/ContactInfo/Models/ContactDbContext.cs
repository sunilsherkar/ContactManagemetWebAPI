using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContactInfo.Models;


namespace ContactInfo.Models
{
    public class ContactDbContext : DbContext
    {
        static ContactDbContext()
        {
            Database.SetInitializer<ContactDbContext>(null);
        }
        public ContactDbContext()
            : base("Name=ContactDbContext")
        {
        }
         
        public DbSet<ContactList> ContactLists { get; set; }
    }
}