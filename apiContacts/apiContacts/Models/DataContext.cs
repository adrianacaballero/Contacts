﻿
namespace apiContacts.Models
{
    using System.Data.Entity;
    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiContacts.Models.Contacts> Contacts { get; set; }
    }
}