using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using Test.Services;
using TestConsole.Services;

namespace Test
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
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
                //.AddMemoryCache()
                .AddSingleton<IConfigurationRoot>(Configuration)
                .AddSingleton<IRolesServices, RolesServices>()
                .AddSingleton<IPeople, People>()
                .AddSingleton<IEncryptService, EncryptService>()
                .AddSingleton<ITokenService, TokenService>()
                .AddSingleton<IDocumentoService, DocumentoService>()
                ;
        }

    }
}