using AutoMapper;
using BuyEmAll.API.Extensions;
using BuyEmAll.API.Helpers;
using BuyEmAll.API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BuyEmAll.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationService(Configuration);

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            services.AddDatabaseService(Configuration);

            services.AddIdentityService(Configuration); // Identity & Authentication

            services.AddControllers();

            services.AddSwaggerService();

            //services.AddCors(options => {
            //    options.AddPolicy("BasePolicy", policy =>
            //    {
            //        var f = Configuration["AppSettings:AllowedOrigins"];
            //        policy
            //            .WithOrigins(Configuration["AppSettings:AllowedOrigins"])
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});

            services.AddApiValidationService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");  //

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("BasePolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseSwaggerService();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
