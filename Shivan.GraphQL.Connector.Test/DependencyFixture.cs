using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shivan.GraphQL.Connector.Services;
using Xunit.Abstractions;

namespace Shivan.GraphQL.Connector.Test
{
    public class DependencyFixture
    {
        public IServiceProvider? ServiceProvider { get; set; }
        public ITestOutputHelper? OutputHelper { get; set; }

        public void DependencyFactoryFixtureBuilder()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IVismaBusinessNXTService, VismaBusinessNXTService>();
            services.AddHttpClient("vbnxtservice");

            ServiceProvider = services.BuildServiceProvider();
        }

        public DependencyFixture ConfigureSingletonInstances(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            DependencyFactoryFixtureBuilder();
            var superOfficeService = ServiceProvider?.GetRequiredService<IVismaBusinessNXTService>();

            return this;
        }
    }
}
