using Microsoft.Extensions.DependencyInjection;
using LR1.Services;

namespace LR1
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddSingleton<InsurancePolicyService>();
    }
}
