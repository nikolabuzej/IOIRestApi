using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOIModel
{
  public  class IOIContext: DbContext
    {
        public DbSet<IOI> IOI { get; set; }
        public DbSet<Warranty> Warranties{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=IOI;");
        }
    }
}
