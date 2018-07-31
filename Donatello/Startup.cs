using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.Infrastructure;
using Donatello.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Donatello
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // For DI Pattern
            services.AddScoped<BoardService>();

            services.AddMvc();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Donatello";
            services.AddDbContext<DonatelloContext>(options => options.UseSqlServer(connection));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
