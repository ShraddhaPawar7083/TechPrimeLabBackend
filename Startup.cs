using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechPrimeLab.Models;
using TechPrimeLab.Data; // Replace with your namespace

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Configure ApplicationDbContext and specify SQL Server connection string
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add ASP.NET Core Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // Add controllers and enable API behavior
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure pipeline
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Enable routing and endpoints
        app.UseRouting();

        // Enable authentication and authorization
        app.UseAuthentication();
        app.UseAuthorization();

        // Use endpoints for MVC
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
