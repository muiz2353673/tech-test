// File: UserService.cs — user domain service implementation
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

/// <summary>
/// Default implementation of <see cref="IUserService"/> backed by <see cref="IDataContext"/>.
/// Uses simple in-memory EF Core queries via the injected context.
/// </summary>
public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    // We take the data context in the constructor so we can get data from the DB
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    // This filters users by if they are active or not
    public IEnumerable<User> FilterByActive(bool isActive)
    {
        return _dataAccess.GetAll<User>().Where(u => u.IsActive == isActive);
    }

    // Get all the users (sync)
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();

    // Find a specific user by id (sync)
    public User? GetById(long id)
    {
        return _dataAccess.GetAll<User>().FirstOrDefault(u => u.Id == id);
    }

    // Add a new user (sync)
    public void Add(User user)
    {
        _dataAccess.Create(user);
    }

    // Update an existing user (sync)
    public void Update(User user)
    {
        _dataAccess.Update(user);
    }

    // Delete a user by id (sync)
    public void Delete(long id)
    {
        var user = GetById(id);
        if (user != null)
        {
            _dataAccess.Delete(user);
        }
    }

    // Get all users using async friendly API
    public Task<IEnumerable<User>> GetAllAsync()
        => Task.FromResult(_dataAccess.GetAll<User>().AsEnumerable());

    // Find a specific user by id using async pattern
    public Task<User?> GetByIdAsync(long id)
        => Task.FromResult(_dataAccess.GetAll<User>().FirstOrDefault(u => u.Id == id));

    // Add a new user async
    public Task AddAsync(User user)
        => _dataAccess.CreateAsync(user);

    // Update a user async
    public Task UpdateAsync(User user)
        => _dataAccess.UpdateAsync(user);

    // Delete a user async (we load the user first to remove it)
    public async Task DeleteAsync(long id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            await _dataAccess.DeleteAsync(user);
        }
    }
}
