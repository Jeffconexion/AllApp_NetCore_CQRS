using AppTodo.Application.Commands;
using AppTodo.Application.Commands.Handlers.Contracts;
using AppTodo.Application.Commands.Handlers.CreateTodo;
using AppTodo.Application.Commands.Handlers.MarkTodoAsDone;
using AppTodo.Application.Commands.Handlers.MarkTodoAsUndone;
using AppTodo.Application.Commands.Handlers.UpdateTodo;
using AppTodo.Core.IRepositories;
using AppTodo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using static AppTodo.Api.Configuration.SwaggerConfig;

namespace AppTodo.Api.Configuration
{
  public static class DependencyInjectionConfig
  {
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
      services.AddTransient<ITodoRepository, TodoRepository>();
      services.AddTransient<IHandler<CreateTodoCommand>, CreateTodoCommandHandler>();
      services.AddTransient<IHandler<MarkTodoAsDoneCommand>, MarkTodoAsDoneCommandHandler>();
      services.AddTransient<IHandler<MarkTodoAsUndoneCommand>, MarkTodoAsUndoneCommandHandler>();
      services.AddTransient<IHandler<UpdateTodoCommand>, UpdateTodoCommandHandler>();
      services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

      return services;
    }
  }
}
