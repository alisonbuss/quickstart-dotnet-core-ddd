
using System.Threading.Tasks;
using System.Collections.Generic;

using ExampleUsersDDD.Common.Interfaces;
using ExampleUsersDDD.Common.Implementations;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Enums;

namespace  ExampleUsersDDD.Domain.Interfaces.Services
{
    public interface IServiceUser : INotificationHandler<Notification>
    {
        // Reading(Consultation):
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersByStatus(AccountStatus status);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);

        // Writing(Persistence):
        Task<User> CreateUserAccount(User user);
        Task<User> ActivateUserAccount(int id);
        Task<User> DisableUserAccount(int id);
        Task<User> BlockUserAccount(int id);
        Task<User> UpdateUserData(User user);
        Task DeleteUserAccount(int id);
        Task ChangePasswordFromUserAccount(int id, string currentPassword, string newPassword);

        // Consume Services:
        Task AddUserOnSession(User user);
        Task DeleteUserFromSession(int id);
        Task<User> GetUserByIdFromSession(int id);
        Task<IEnumerable<User>> GetAllUsersFromSession();
    }
}
