﻿using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SurviveOnSotka
{
    public class Program
    {
        public static async Task Main(string[] args) => await BuildWebHost(args).RunAsync();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseWebRoot("static")
                .Build();
    }
}