using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RunscapeMinigames;
using RunscapeUser;

namespace RunescapeMinigamesASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Clan cl = new Clan("Consentus");
            //RunescapeMinigames RM = new RunescapeMinigames(8648);
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
