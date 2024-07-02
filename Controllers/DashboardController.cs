using Microsoft.AspNetCore.Mvc;
using TechPrimeLab.Data;

namespace TechPrimeLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardData = await _dashboardRepository.GetDashboardDataAsync();
            return Ok(dashboardData);
        }
    }

}
