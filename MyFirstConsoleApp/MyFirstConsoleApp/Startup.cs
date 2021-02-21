using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyFirstConsoleApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {

        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
               {
                   await context.Response.WriteAsync("Hello Kitty");
               });
            });
        }
    }
}
