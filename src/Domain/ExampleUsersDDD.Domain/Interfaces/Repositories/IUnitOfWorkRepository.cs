
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUsersDDD.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository
    {
        Task<int> Commit();

        Task Rollback();

        // ...
        
        IRepositoryProduct RepositoryProduct { get; }
     
    }
}
