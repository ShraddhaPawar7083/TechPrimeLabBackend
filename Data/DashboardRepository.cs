using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechPrimeLab.Models;

namespace TechPrimeLab.Data
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ProjectManagementContext _context;

        public DashboardRepository(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            var statusCounters = await _context.Projects
                .GroupBy(p => 1)
                .Select(g => new StatusCounter
                {
                    TotalProjects = g.Count(),
                    RunningProjects = g.Count(p => p.Status == "Running"),
                    ClosedProjects = g.Count(p => p.Status == "Closed"),
                    CancelledProjects = g.Count(p => p.Status == "Cancelled")
                    // Add other counters as needed
                }).FirstOrDefaultAsync();

            var departmentCompletionReports = await _context.Projects
                .Where(p => p.Status == "Completed")
                .GroupBy(p => p.Department)
                .Select(g => new DepartmentCompletionReport
                {
                    Department = g.Key,
                    CompletedProjects = g.Count()
                }).ToListAsync();

            return new DashboardDataDto
            {
                StatusCounters = statusCounters,
                DepartmentCompletionReports = departmentCompletionReports
            };
        }
    }
}
