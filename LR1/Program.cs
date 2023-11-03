using LR1;
using LR1.Services;
using Microsoft.Extensions.DependencyInjection;
public class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        Startup startup = new Startup();
        startup.ConfigureServices(services);

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        var insurancePolicyService = serviceProvider.GetService<InsurancePolicyService>();

        insurancePolicyService.Init();
    }
    
}
