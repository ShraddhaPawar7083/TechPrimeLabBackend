using Microsoft.AspNetCore.Mvc;
using TechPrimeLab.Data;
using TechPrimeLab.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TechPrimeLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public LoginController(ProjectManagementContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { Success = "False", Message = "Invalid User" });
            }

            return Ok(new { Success = "True", Message = "Valid User" });
        }
    }
}
