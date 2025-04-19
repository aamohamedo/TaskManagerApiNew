using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<TaskItemModel> Tasks { get; set; }
    }
}