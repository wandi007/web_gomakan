using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace web_gomakan
{
    public class Program
    {
        
        private static readonly string EnvironmentName;
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}