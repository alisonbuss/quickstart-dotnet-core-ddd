
using System.Collections.Generic;
using System.Threading.Tasks;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Enums;

namespace  ExampleUsersDDD.Domain.Interfaces.Services
{
    public interface IServiceSession<TEntity> where TEntity : class
    {
        // Consume Cache Service:
        Task AddOnSession(int id, TEntity entity);
        Task DeleteFromSession(int id);
        Task<User> GetByIdOnSession(int id);
        Task<IEnumerable<User>> GetAllFromSession();
    }
}
