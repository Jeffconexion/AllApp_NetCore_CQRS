using AppTodo.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
      services.AddDependencyInjectionDataBaseConfig(Configuration);
      services.AddApiConfig();
      services.AddSwaggerConfig();
      services.ResolveDependencies();
      services.AddConfigFirebase();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
      app.UseApiConfig(env);
      app.UseSwaggerConfig(provider);
    }
  }
}
