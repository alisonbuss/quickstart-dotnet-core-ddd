
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using ExampleUsersDDD.Common.Interfaces;
using ExampleUsersDDD.Common.Implementations;

using ExampleUsersDDD.Domain.Enums;

using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Interfaces
{
    public interface IAppServiceUser : INotificationHandler<Notification>, IDisposable
    {
        // Reading(Consultation):
        Task<IEnumerable<DtoUser>> GetAllUsers();
        Task<IEnumerable<DtoUser>> GetAllUsersByStatus(AccountStatusEnum status);
        Task<DtoUser> GetUserById(int id);
        Task<DtoUser> GetUserByEmail(string email);

        // Writing(Persistence):
        Task<DtoUser> CreateUserAccount(DtoUserRegistration user);
        Task<DtoUser> ActivateUserAccount(int id);
        Task<DtoUser> DisableUserAccount(int id);
        Task<DtoUser> BlockUserAccount(int id);
        Task<DtoUser> UpdateUserData(DtoUserUpdate user);
        Task DeleteUserAccount(int id);
        Task ChangePasswordFromUserAccount(int id, DtoChangePassword dtoChangePassword);

        // Consume Services:
        Task AddUserOnSession(DtoUser user);
        Task DeleteUserFromSession(int id);
        Task<DtoUser> GetUserByIdFromSession(int id);
        Task<IEnumerable<DtoUser>> GetAllUsersFromSession();
        
    }
}
