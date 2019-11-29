namespace apiContactsSecurity.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiContactsSecurity.Models.Contacts> Contacts { get; set; }
    }
}