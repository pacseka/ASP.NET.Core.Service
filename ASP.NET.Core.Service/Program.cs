using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ASP.NET.Core.Service
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var pathToContentRoot = Directory.GetCurrentDirectory();


            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(pathToContentRoot)
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            host.Run();

        }
    }

}
