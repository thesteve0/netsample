﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;



namespace WebCore.netsample
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var config = new ConfigurationBuilder()
                .AddEnvironmentVariables("")
            .Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(url)
                .Build();

            host.Run();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }

    }
}
