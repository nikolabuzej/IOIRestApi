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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IOI>().HasKey(p => p.IOIid);
            modelBuilder.Entity<IOI>().HasOne(p => p.Warranty);
            base.OnModelCreating(modelBuilder);
        }
    }
}
