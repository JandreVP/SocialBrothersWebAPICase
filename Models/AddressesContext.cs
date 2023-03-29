using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace SocialBrothersWebAPICase.Models
{
    public class AddressesContext : DbContext
    {

        public AddressesContext(DbContextOptions<AddressesContext> options) : base(options)
        {
        
        }
        public DbSet<address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=address.db");
        }



    }
}
