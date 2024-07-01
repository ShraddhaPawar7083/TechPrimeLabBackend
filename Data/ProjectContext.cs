using System.Collections.Generic;
using TechPrimeLab.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace TechPrimeLab.Data
{  

public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }

}
