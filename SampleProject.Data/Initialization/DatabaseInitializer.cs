using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace DataLibraryProject
{
    internal class DatabaseInitializer(IServiceProvider serviceProvider) : IDatabaseInitializer
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public async Task InitializeDatabasesAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>()
                .InitializeAsync(cancellationToken);
        }
    }
}