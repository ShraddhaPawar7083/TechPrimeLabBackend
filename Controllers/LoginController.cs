using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Use EF Core namespace for async methods
using System.Threading.Tasks;
using TechPrimeLab.Data;
using TechPrimeLab.Models;

namespace TechPrimeLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ProjectManagementContext _dbContext;

        public LoginController(ProjectManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Query the database to find the user
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Successful login
                    // You can implement further authentication logic here if needed
                    return Ok("Login Successful");
                }
                else
                {
                    // Failed login attempt
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                    return BadRequest(ModelState);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Implement logout logic if needed
            return Ok("Logout Successful");
        }
    }
}
