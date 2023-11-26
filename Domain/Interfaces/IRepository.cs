using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository <T> where T : IEntity
{
    Task<ICollection<Product?>> GetAll();
    Task<T?> GetById(int id);
}