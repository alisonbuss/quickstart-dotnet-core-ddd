
// Unit of Work for ASP.NET Core
// Font: https://medium.com/@chathuranga94/unit-of-work-for-asp-net-core-706e71abc9d1

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
