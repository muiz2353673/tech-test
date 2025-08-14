// File: ServiceCollectionExtensions.cs — DI registration for data access
using UserManagement.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
        => services.AddScoped<IDataContext, DataContext>();
}
