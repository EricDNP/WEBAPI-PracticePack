using Application.Configurations;
using Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Serverless.Configuration
{
    public static class DI
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            services.AddApplication();
            services.AddInfrastructure(configuration);

            return services.BuildServiceProvider();
        }
    }
}
