using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(p => p.StartDate)
                .HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.EndDate)
               .HasDefaultValueSql("DATEADD(DAY, 1, GETDATE())");
            });
        }


        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users{ get; set; }


    }
}
