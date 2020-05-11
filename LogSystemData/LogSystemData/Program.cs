using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LogSystemData
{
    public class Program
    {
        public static void Main( string[] args )
        {
            RunInConsoleMode( args );
        }

        public static void RunInConsoleMode( string[] args )
        {
            string environment = Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" );
            WebHost.CreateDefaultBuilder( args )
                .UseStartup<Startup>()
                .ConfigureAppConfiguration( ( builderContext, config ) =>
                {
                    config.AddJsonFile( "appsettings.json" )
                        .AddJsonFile( $"appsettings.{ environment }.json", true );
                } )
                .Build()
                .Run();
        }
    }
}
