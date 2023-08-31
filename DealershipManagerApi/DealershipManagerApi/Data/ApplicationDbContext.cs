using DealershipManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManagerApi.Data
{
    //AplicationDbContext = Abstractizare asupra bazei de date 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Abstractizare a tabelului CARS din SQL Database
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
