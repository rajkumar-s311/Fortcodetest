using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FortCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
           BuildWebHost(args).Run();
        }

        //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //        WebHost.CreateDefaultBuilder(args)
        //            .ConfigureAppConfiguration(((context, config) =>
        //            {
        //                config.AddEnvironmentVariables("FORTCODEENV_");
        //            }))
        //            .UseStartup<Startup>();
        //}
        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();
    }
}