using AppTodo.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppTodo.Api.Configuration
{
  public static class IdentityConfig
  {
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
           IConfiguration configuration)
    {

      //configuration context identity in ApplicationDbContext
      services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("connectionString")));

      // I add from fact the identity in aplication
      services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

      return services;

    }
  }
}
