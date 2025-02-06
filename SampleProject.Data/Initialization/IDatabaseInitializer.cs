using System.Threading;
using System.Threading.Tasks;

namespace DataLibraryProject;
public interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken = default);
}
