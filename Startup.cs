using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Test.Services;

namespace Test
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                    //.AddJsonFile("D:/Desktop/WorkspaceVSCode/C#/Test/appsettings.json")
                    .Build();
        }

        public IServiceCollection ConfigureServices()
        {
              return new ServiceCollection()
                .AddLogging(logging =>
                {
                    logging.AddConfiguration(Configuration.GetSection("Logging"));
                    logging.AddConsole();
                }).Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
                .AddMemoryCache()
                .AddSingleton<IConfigurationRoot>(Configuration)
                .AddSingleton<IRolesServices, RolesServices>()
                .AddSingleton<IPeople, People>()
                .AddSingleton<IEncryptService, EncryptService>()
                .AddSingleton<ITokenService, TokenService>()
                ;
        }

    }
}