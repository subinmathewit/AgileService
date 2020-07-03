using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileDashBoardService.Data.DB
{
    public class AgileDbContext : DbContext
    {
       
        public AgileDbContext(DbContextOptions<AgileDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Stories> Stories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stories>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(p => p.StoryName).IsRequired().HasMaxLength(1000);
                entity.Property(p => p.StoryPoint).IsRequired();

            });
        }
    }
}
