using DataLibraryProject;

namespace Microsoft.Extensions.DependencyInjection;
public static class Startup
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {  

        return services.AddTransient<IDatabaseInitializer, DatabaseInitializer>()
                       .AddTransient<ApplicationDbInitializer>() ;
    }
}
