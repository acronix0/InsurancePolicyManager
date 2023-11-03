using Microsoft.Extensions.DependencyInjection;
using LR1.Services;
using LR1.Views;

namespace LR1
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddSingleton<InsurancePolicyService>();
            services.AddSingleton<ConsoleView>();
        }

    }
}
