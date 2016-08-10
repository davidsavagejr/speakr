using System.IO;
using System.Security.Principal;
using Microsoft.AspNetCore.Hosting;

namespace Web.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        internal static IPrincipal DebugUser { get; set; }
    }
}
