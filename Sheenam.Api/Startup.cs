//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//============================================
    
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Sheenam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;        

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(option =>
            {
                var ApiInfo = new OpenApiInfo { Title = "Sheenam.Api", Version = "v1" };
                option.SwaggerDoc(
                    name: "v1", 
                    info: ApiInfo);
            });
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseDeveloperExceptionPage();
                application.UseSwaggerUI(option => option.SwaggerEndpoint(
                    url:"/swagger/v1/swagger.json", 
                    name: "Sheenam.Api v1"));
            }

            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseAuthorization();

            application.UseEndpoints(endpoints =>
                 endpoints.MapControllers());
        }
    }
}
