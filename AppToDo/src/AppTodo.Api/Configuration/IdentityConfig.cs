using System.Text;
using AppTodo.Api.Data;
using AppTodo.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

      //Set two line to use data appsetings.
      var appSettingsSection = configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      //// Get Key and encode
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);


      // Add Authenthication
      // Implementation JWT
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = true; //required type https
        x.SaveToken = true; //register token
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = appSettings.ValidIn,
          ValidIssuer = appSettings.Issuer
        };
      });

      return services;

    }
  }
}
