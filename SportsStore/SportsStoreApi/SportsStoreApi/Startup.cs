using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SportsStoreApi.DataAccess.Ef;

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
            var dbContextSettings = new SportsStoreDbContextSettings
            {
                ConnectionString = Configuration["Data:SportsStoreDb:ConnectionString"]
            };

            services.TryAddSingleton<SportsStoreDbContextSettings>(dbContextSettings);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SportsStoreDbContext>(builder =>
                {
                    builder.UseSqlServer(dbContextSettings.ConnectionString);
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<SportsStoreDbContext>().Database.Migrate();
            }

            app.UseMvc();
        }
    }
}
