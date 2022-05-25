using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AppTodo.Api.Configuration
{
  public static class ConfigAuthGoogle
  {
    public static IServiceCollection AddConfigFirebase(this IServiceCollection services)
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.Authority = "https://securetoken.google.com/todo-12903";
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/todo-12903",
            ValidateAudience = true,
            ValidAudience = "todo-12903",
            ValidateLifetime = true
          };
        });

      return services;
    }
  }
}
