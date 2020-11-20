using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore5MemoryTest
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductionPlan> ProductionPlans { get; set; }
        public DbSet<PlanItem> PlanItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connStr = "";
            if (string.IsNullOrWhiteSpace(connStr))
            {
                throw new Exception("Missing DB connection string");
            }
            options.UseSqlServer(connStr);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionPlan>().ToTable("ProductionPlan");
            modelBuilder.Entity<PlanItem>().ToTable("PlanItem");
        }
    }
}
