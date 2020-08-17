
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using ExampleUsersDDD.Common.Implementations;

using ExampleUsersDDD.Domain.Enums;
using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Services;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Services
{
    public class AppServiceUser : Notify, IAppServiceUser
    {
        //private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IServiceUser serviceUser;

        public AppServiceUser(
            IMapper mapper, IServiceUser serviceUser)
        {
            //this.logger = logger;
            this.mapper = mapper;
            this.serviceUser = serviceUser;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<DtoUser>> GetAllUsers()
        {
            return this.mapper.Map<IEnumerable<DtoUser>>(
                await this.serviceUser.GetAllUsers()
            );
        }

        public async Task<IEnumerable<DtoUser>> GetAllUsersByStatus(AccountStatus status)
        {
            return this.mapper.Map<IEnumerable<DtoUser>>(
                await this.serviceUser.GetAllUsersByStatus(status)
            );
        }

        public async Task<DtoUser> GetUserById(int id)
        {
            return this.mapper.Map<DtoUser>(
                await this.serviceUser.GetUserById(id)
            );
        }

        public async Task<DtoUser> GetUserByEmail(string email)
        {
            return this.mapper.Map<DtoUser>(
                await this.serviceUser.GetUserByEmail(email)
            );
        }

        // Writing(Persistence):
        public async Task<DtoUser> CreateUserAccount(DtoUser dtoUser)
        {
            var currentUser = this.mapper.Map<User>(dtoUser);

            var newUser = await this.serviceUser.CreateUserAccount(currentUser);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            return this.mapper.Map<DtoUser>(newUser);
        }

        public async Task<DtoUser> ActivateUserAccount(int id)
        {
            var user = await this.serviceUser.ActivateUserAccount(id);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            return this.mapper.Map<DtoUser>(user);
        }

        public async Task<DtoUser> DisableUserAccount(int id)
        {
            var user = await this.serviceUser.DisableUserAccount(id);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            return this.mapper.Map<DtoUser>(user);
        }

        public async Task<DtoUser> BlockUserAccount(int id)
        {
            var user = await this.serviceUser.BlockUserAccount(id);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            return this.mapper.Map<DtoUser>(user);
        }
        
        public async Task<DtoUser> UpdateUserData(DtoUser dtoUser)
        {
            var currentUser = this.mapper.Map<User>(dtoUser);

            var userModified = await this.serviceUser.UpdateUserData(currentUser);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            return this.mapper.Map<DtoUser>(userModified);
        }

        public async Task DeleteUserAccount(int id)
        {
            await this.serviceUser.DeleteUserAccount(id);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async Task ChangePasswordFromUserAccount(int id, DtoChangePassword dtoChangePassword)
        {
            await this.serviceUser.ChangePasswordFromUserAccount(id, dtoChangePassword.Password, dtoChangePassword.NewPassword);

            if(this.serviceUser.HasNotifications())
                this.NewNotifications(this.serviceUser.Notifications());
            
            await Task.CompletedTask.ConfigureAwait(false);
        }
        
        // Consume Services:
        public Task AddUserOnSession(DtoUser dtoUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserFromSession(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DtoUser> GetUserByIdFromSession(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DtoUser>> GetAllUsersFromSession()
        {
            throw new NotImplementedException();
        }

        // From class:
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
