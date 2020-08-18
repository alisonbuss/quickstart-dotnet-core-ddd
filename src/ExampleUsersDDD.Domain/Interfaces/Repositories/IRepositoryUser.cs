
using System.Threading.Tasks;
using System.Collections.Generic;

using ExampleUsersDDD.Domain.Enums;
using ExampleUsersDDD.Domain.Entities;

namespace ExampleUsersDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        // Reading(Consultation):
        Task<User> GetByEmail(string email);
        Task<IList<User>> GetAllByStatus(AccountStatusEnum status);

    }
}
