using AppTodo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppTodo.Api.Configuration
{
  public static class DependencyInjectionDataBaseConfig
  {
    public static IServiceCollection AddDependencyInjectionDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
      //the same addScoped, but specify to database.
      //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));//memory

      //Other databases.
      services.AddDbContext<DataContext>(opt => { opt.UseSqlServer(configuration.GetConnectionString("connectionString")); });//sql server
      return services;
    }

  }
}
