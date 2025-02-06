using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataLibraryProject
{
    internal class ApplicationDbInitializer(SampleProjectDbContext dbContext, ILogger<ApplicationDbInitializer> logger)
    {
        private readonly SampleProjectDbContext _dbContext = dbContext;
        private readonly ILogger<ApplicationDbInitializer> _logger = logger;
        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (_dbContext.Database.GetMigrations().Any())
            {
                if ((await _dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
                {
                    _logger.LogInformation("Applying Migrations");
                    await _dbContext.Database.MigrateAsync(cancellationToken);
                }

                if (await _dbContext.Database.CanConnectAsync(cancellationToken))
                {
                    _logger.LogInformation("Connection to Database Succeeded.");
                }
            }
        }
    }
}