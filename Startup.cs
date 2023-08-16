
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      if (Environment.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseAuthentication();

      // with controllers
      app.UseHttpsRedirection();
      app.UseCors("MyPolicy");
      app.UseRouting();
      // app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
