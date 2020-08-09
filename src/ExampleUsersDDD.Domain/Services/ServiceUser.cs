
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using ExampleUsersDDD.Common.Implementations;

using ExampleUsersDDD.Domain.Enums;
using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Services;
using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Domain.Validators;

namespace ExampleUsersDDD.Domain.Services
{
    public class ServiceUser : Notify, IServiceUser
    {
        private readonly IUnitOfWorkRepository kraken;
        private readonly IServiceSession<User> serviceSession;

        public ServiceUser(
            IUnitOfWorkRepository unitOfWorkRepository, IServiceSession<User> serviceSession)
        {
            this.kraken = unitOfWorkRepository;
            this.serviceSession = serviceSession;
        }

        private async Task<bool> ExistsUserRegisteredByEmail(string email)
        {
            var user = await this.GetUserByEmail(email);
            return user != null;
        }

        private async Task<User> ModifUserStatus(int id, AccountStatus status)
        {
            try
            {
                var user = await this.kraken.RepositoryUser.GetById(id);

                if (user == null) 
                {
                    this.NewNotification("User", "User does not exist.");
                    return user;
                }

                user.Status = status;

                var userModified = await this.kraken.RepositoryUser.Update(user);
                await this.kraken.Commit();

                return userModified;
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        // Reading(Consultation):
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await this.kraken.RepositoryUser.GetAll();
        }

        public async Task<IEnumerable<User>> GetAllUsersByStatus(AccountStatus status)
        {
            return await this.kraken.RepositoryUser.GetAllByStatus(status);
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.kraken.RepositoryUser.GetById(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await this.kraken.RepositoryUser.GetByEmail(email);
        }

        // Writing(Persistence):
        public async Task<User> CreateUserAccount(User user)
        {
            try
            {
                if (user == null) 
                {
                    this.NewNotification("User", "The set user is null.");
                    return user;
                }

                var validationResult = (new ValidatorUser()).Validate(user);

                if(!validationResult.IsValid) 
                    this.NewNotifications(validationResult);

                if (await this.ExistsUserRegisteredByEmail(user.Email))
                    this.NewNotification("Email", "User with this email already registered.");
                
                if (this.HasNotifications())
                    return await Task.FromResult<User>(user);

                var newUser = await this.kraken.RepositoryUser.Add(user);
                await this.kraken.Commit();

                return newUser;
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        public async Task<User> ActivateUserAccount(int id)
        {
            return await this.ModifUserStatus(id, AccountStatus.Active);
        }

        public async Task<User> DisableUserAccount(int id)
        {
            return await this.ModifUserStatus(id, AccountStatus.Disabled);
        }

        public async Task<User> BlockUserAccount(int id)
        {
            return await this.ModifUserStatus(id, AccountStatus.Blocked);
        }
        
        public async Task<User> UpdateUserData(User user)
        {
            try
            {
                if (user == null) 
                {
                    this.NewNotification("User", "The set user is null.");
                    return user;
                }

                var validationResult = (new ValidatorUser()).Validate(user);

                if(!validationResult.IsValid) 
                    this.NewNotifications(validationResult);
                
                if (this.HasNotifications())
                    return await Task.FromResult<User>(user);

                var userModified = await this.kraken.RepositoryUser.Update(user);
                await this.kraken.Commit();

                return userModified;
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        public async Task DeleteUserAccount(User user)
        {
            try
            {
                if (user == null) 
                {
                    this.NewNotification("User", "The set user is null.");
                    await Task.CompletedTask.ConfigureAwait(false);;
                } 
                else
                {
                    await this.kraken.RepositoryUser.Remove(user);
                    await this.kraken.Commit();
                }
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        public async Task ChangePasswordFromUserAccount(User user, string currentPassword, string newPassword)
        {
            try
            {
                if (user == null) 
                {
                    this.NewNotification("User", "The set user is null.");
                    await Task.CompletedTask.ConfigureAwait(false);;
                } 
                else
                {
                    var currentUser = await this.kraken.RepositoryUser.GetById(user.Id);

                    if(currentUser.Password != currentPassword)
                        this.NewNotification("Password", "The password passed by the current user is invalid.");

                    currentUser.Password = newPassword;

                    await this.kraken.RepositoryUser.Update(currentUser);
                    await this.kraken.Commit();
                }
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }
        
        // Consume Services:
        public Task AddUserOnSession(User User)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserFromSession(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdFromSession(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersFromSession()
        {
            throw new NotImplementedException();
        }

    }
}
