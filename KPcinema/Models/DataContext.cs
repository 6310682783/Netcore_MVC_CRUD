using Microsoft.EntityFrameworkCore;

namespace KPcinema.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
    }
}
