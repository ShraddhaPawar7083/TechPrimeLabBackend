using Microsoft.EntityFrameworkCore;
using TechPrimeLab.Models;

namespace TechPrimeLab.Data
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
