using DataDrivenField.Models;
using System.Data.Entity;

namespace DataDrivenField.EF
{
    public class DataEntryContext : DbContext
    {
        public DataEntryContext() : base("DEConnSt")
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<DataEntry> DataEntries { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}