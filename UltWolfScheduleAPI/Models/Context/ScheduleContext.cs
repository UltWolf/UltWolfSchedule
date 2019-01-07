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
        public DbSet<User> Users { get; set; }
        public DbSet<OrdinaryTask> OrdTasks { get; set; } 
    }
}
