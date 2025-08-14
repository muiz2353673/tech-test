// File: IUserService.cs — user service contract
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services.Domain.Interfaces;

/// <summary>
/// Domain service for querying and mutating <see cref="User"/> entities.
/// Provides both synchronous and asynchronous APIs for convenience.
/// </summary>
public interface IUserService 
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    IEnumerable<User> GetAll();
    User? GetById(long id);
    void Add(User user);
    void Update(User user);
    void Delete(long id);

    // Async APIs
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(long id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(long id);
}
