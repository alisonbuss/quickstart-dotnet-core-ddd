
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Services;

namespace ExampleUsersDDD.Domain.Services
{
    public class ServiceSession<TEntity> : IServiceSession<TEntity> where TEntity : class
    {
        public Task AddOnSession(int id, TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteFromSession(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllFromSession()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdOnSession(int id)
        {
            throw new System.NotImplementedException();
        }
        
    }
}