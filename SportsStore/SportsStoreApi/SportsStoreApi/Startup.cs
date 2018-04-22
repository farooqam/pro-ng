using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SportsStoreApi.DataAccess.Ef;
using SportsStoreApi.DataAccess.Ef.SeedData;

namespace SportsStoreApi
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
            ConfigureEf(services);
            services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            RunEfMigrations(app, dbContext =>
            {
                if (!env.IsDevelopment())
                {
                    return;
                }

                SportsStoreDbSeeder.ClearData(dbContext);
                SportsStoreDbSeeder.SeedData(dbContext);
            });
            
            app.UseMvc();
        }

        private static void RunEfMigrations(IApplicationBuilder app, Action<SportsStoreDbContext> seedData)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SportsStoreDbContext>();
                dbContext.Database.Migrate();
                seedData(dbContext);
            }
        }

        private void ConfigureEf(IServiceCollection services)
        {
            var dbContextSettings = new SportsStoreDbContextSettings
            {
                ConnectionString = Configuration["Data:SportsStoreDb:ConnectionString"]
            };

            services.TryAddSingleton(dbContextSettings);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SportsStoreDbContext>(builder =>
                {
                    builder.UseSqlServer(dbContextSettings.ConnectionString);
                });
        }

    }
}