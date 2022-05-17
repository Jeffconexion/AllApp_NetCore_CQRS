using AppTodo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppTodo.Api.Configuration
{
  public static class DependencyInjectionDataBaseConfig
  {
    public static IServiceCollection AddDependencyInjectionDataBaseConfig(this IServiceCollection services)
    {
      //the same addScoped, but specify to database.
      services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

      //Other databases.
      /*
      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      });
      */

      return services;
    }

  }
}
