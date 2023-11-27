using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Interface for repository with common methods
/// </summary>
/// <typeparam name="T">IEntity</typeparam>
public interface IRepository <T> where T : IEntity
{
    /// <summary>
    /// Get all items from repository.
    /// </summary>
    /// <returns>Items of type T</returns>
    Task<ICollection<T?>> GetAll();

    /// <summary>
    /// Get specific range of items. Used for pagination.
    /// </summary>
    /// <param name="offset">Offset (starting point).</param>
    /// <param name="limit">Maximum number for one request.</param>
    /// <returns></returns>
    Task<ICollection<T?>> GetAll(int offset, int limit);

    /// <summary>
    /// Get one item from repository.
    /// </summary>
    /// <param name="id">Unique id.</param>
    /// <returns>One item or null.</returns>
    Task<T?> GetById(int id);
}