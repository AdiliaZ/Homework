using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my first Middleware!");

            //    await next();

            //    await context.Response.WriteAsync("Hello from my first Middleware response!");

            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my second Middleware!");

            //    await next();

            //    await context.Response.WriteAsync("Hello from my second Middleware response!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from my third Middleware!");

            //    await next();
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context =>
                {
                    if(env.IsDevelopment())
                    {
                        await context.Response.WriteAsync("Hello from dev");
                    }
                  else  if (env.IsProduction())
                    {
                        await context.Response.WriteAsync("Hello from prod");
                    }
                    else if (env.IsStaging())
                    {
                        await context.Response.WriteAsync("Hello from stag");
                    }
                    else if(env.IsEnvironment("Develop"))
                    {
                        await context.Response.WriteAsync("Hello from custom name");

                    }
                    else
                    await context.Response.WriteAsync(env.EnvironmentName);
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/Kitty", async context =>
                {
                    await context.Response.WriteAsync("Hello Kitty!");
                });
            });
        }
    }
    }
