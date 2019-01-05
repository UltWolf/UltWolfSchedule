using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltWolfScheduleAPI.Models.ManyToMany;

namespace UltWolfScheduleAPI.Models.Context
{
    public class ScheduleContext:DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> dbContext) : base(dbContext)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOrdinaryTask>()
                .HasKey(t => new { t.UserId, t.OrdinaryTaskId });
            modelBuilder.Entity<UserMultipleTask>()
            .HasKey(t => new { t.UserId, t.MultipleTaskId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OrdinaryTask> OrdTasks { get; set; }
        public DbSet<MultipleTask> MulTasks { get; set; }
    }
}
