using AdresBeheerBusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace AdresBeheerRepository
{
    public class AdresContext : DbContext
    {
        public DbSet<Gemeente> gemeenten {get; set;}
        public DbSet<Adres> adressen { get; set; }
        public DbSet<Straat> straten { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AOCWS947;Initial Catalog=adresBeheerTest;Integrated Security=True");
        }
    }
}
