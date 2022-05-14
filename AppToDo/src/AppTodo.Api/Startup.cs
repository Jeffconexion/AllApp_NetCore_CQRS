using AppTodo.Application.Commands;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Application.Commands.Handlers.CreateTodo;
using AppTodo.Application.Commands.Handlers.MarkTodoAsDone;
using AppTodo.Application.Commands.Handlers.MarkTodoAsUndone;
using AppTodo.Application.Commands.Handlers.UpdateTodo;
using AppTodo.Core.IRepositories;
using AppTodo.Infrastructure.Context;
using AppTodo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AppTodo.Api
{
  /// <summary>
  /// @author: Jefferson Santos
  /// @Data  : 11/05/2022
  /// 
  /// Set and Dependences.
  /// </summary>
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));//the same addScoped, but specify to database.
                                                                                     //services.AddDbContext<DataContext>(opt =>
                                                                                     //{
                                                                                     //  opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                                                                                     //});

      services.AddTransient<ITodoRepository, TodoRepository>();
      services.AddTransient<IHandler<CreateTodoCommand>, CreateTodoCommandHandler>();
      services.AddTransient<IHandler<MarkTodoAsDoneCommand>, MarkTodoAsDoneCommandHandler>();
      services.AddTransient<IHandler<MarkTodoAsUndoneCommand>, MarkTodoAsUndoneCommandHandler>();
      services.AddTransient<IHandler<UpdateTodoCommand>, UpdateTodoCommandHandler>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppTodo.Api", Version = "v1" });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppTodo.Api v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
