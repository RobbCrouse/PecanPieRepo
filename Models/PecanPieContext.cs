using Microsoft.EntityFrameworkCore;

namespace pecanpie.Models
{
    public class PecanPieContext : DbContext
    {
        public PecanPieContext(DbContextOptions<PecanPieContext> options) : base(options){}


        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Joiner> Joiners { get; set; }
    }
}