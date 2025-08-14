// File: IDataContext.cs — abstraction over EF Core data operations
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Data;

/// <summary>
/// Abstraction over the data access layer for simple CRUD operations using EF Core.
/// Implementations should persist changes immediately upon create, update, and delete calls.
/// </summary>
public interface IDataContext
{
    /// <summary>
    /// Returns an <see cref="IQueryable{TEntity}"/> for the requested entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to query.</typeparam>
    /// <returns>An <see cref="IQueryable{TEntity}"/> to compose queries.</returns>
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    /// <summary>
    /// Adds a new entity instance and saves changes.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity instance to add.</param>
    void Create<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Adds a new entity instance and saves changes asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity instance to add.</param>
    Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Updates an existing entity instance and saves changes.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The detached or tracked entity instance to update.</param>
    void Update<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Updates an existing entity instance and saves changes asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The detached or tracked entity instance to update.</param>
    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Removes an entity instance and saves changes.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity instance to remove.</param>
    void Delete<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Removes an entity instance and saves changes asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="entity">The entity instance to remove.</param>
    Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
}
