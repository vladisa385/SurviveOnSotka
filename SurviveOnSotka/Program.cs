using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SurviveOnSotka
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                //var services = scope.ServiceProvider;
                //try
                //{
                //    var userManager = services.GetRequiredService<UserManager<User>>();
                //    var rolesManager = services.GetRequiredService<RoleManager<Role>>();
                //    await DbInitializer.InitializeAsync(userManager, rolesManager);
                //}
                //catch (Exception ex)
                //{
                //    var logger = services.GetRequiredService<ILogger<Program>>();
                //    logger.LogError(ex, "An error occurred while seeding the database.");
                //}
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseWebRoot("static")
                .Build();
    }
}