//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//============================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storage;
using Sheenam.Api.Services.Foundations.Guests;
using Sheenam.Api.Tests.Unit.Services.Foundations.Guests;

namespace Sheenam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Sheenam.Api",
                Version = "v1"
            };

            services.AddDbContext<StorageBroker>();
            services.AddControllers();
            AddBrokers(services);
            AddFoundationService(services);

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                    name: "v1",
                    info: apiInfo);
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(option => option.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Sheenam.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                 endpoints.MapControllers());
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
        }

        private static void AddFoundationService(IServiceCollection services)
        {
            services.AddTransient<IGuestSevice, GuestService>();
        }
    }
}