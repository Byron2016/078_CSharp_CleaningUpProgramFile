using Microsoft.Extensions.DependencyInjection;

namespace _078_CSharp_CleaningUpProgramFile.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
