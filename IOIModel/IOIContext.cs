using Microsoft.EntityFrameworkCore;

namespace IOIModel
{
    public class IOIContext : DbContext
    {
        public DbSet<IOI> IOI { get; set; }
        public DbSet<Warranty> Warranties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=ioi;User Id=sa;Password=First132.;");
        }
    }
}
