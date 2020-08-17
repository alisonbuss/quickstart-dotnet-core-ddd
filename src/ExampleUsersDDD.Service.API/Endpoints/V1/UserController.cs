
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ExampleUsersDDD.Domain.Enums;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Service.API.Endpoints.V1
{
    [ApiController]
    [Route("api/v1/users")]
    [Produces("application/json")]
    public class UserController : ControllerBaseAPI
    {
        private readonly IAppServiceUser appServiceUser;

        public UserController(
            ILogger<UserController> logger, IAppServiceUser appServiceUser
        ) : base(logger)
        {
            this.appServiceUser = appServiceUser;
        }

        // Private Support Methods:

        private async Task<bool> ModelExists(int id)
        {
            Logger.LogInformation("UserController.ModelExists: Call to Method");

            var model = await this.appServiceUser.GetUserById((int) id);
            return model != null;
        }

        // Reading(Consultation):

        // GET: api/v1/users
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<DtoUser>>> ReadAll()
        {
            Logger.LogInformation("UserController.ReadAll: GET: api/v1/users");

            // Testing a delay...
            await Task.Delay(3666);
           
            var models = await this.appServiceUser.GetAllUsers();
            
            return Ok(models);
        }

        // GET: api/v1/users/status/Active
        [HttpGet]
        [Route("status/{status}")]
        public async Task<ActionResult<IEnumerable<DtoUser>>> ReadAllByStatus(string status)
        {
            Logger.LogInformation($"UserController.ReadAllByStatus: GET: api/v1/users/status/{status}");

            if (status.Length == 0)
                return BadRequest("Error: The user STATUS is empty!");

            // Case Insensitive:
            AccountStatus accountStatus = (AccountStatus) Enum.Parse(typeof(AccountStatus), status, true);

            var models = await this.appServiceUser.GetAllUsersByStatus(accountStatus);

            return Ok(models);
        }

        // GET: api/v1/users/666
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<DtoUser>> ReadById(int id)
        {
            Logger.LogInformation($"UserController.ReadById: GET: api/v1/users/{id}");

            var model = await this.appServiceUser.GetUserById((int) id);

            if (model == null)
                return NotFound("Error: The user not found.");

            return Ok(model);
        }

        // GET: api/v1/users/lucifer@email.com
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<DtoUser>> ReadByEmail(string email)
        {
            Logger.LogInformation($"UserController.ReadByEmail: GET: api/v1/users/{email}");

            if (email == null)
                return BadRequest("Error: The user EMAIL is null!");

            var model = await this.appServiceUser.GetUserByEmail(email);

            if (model == null)
                return NotFound("Error: The user not found.");

            return Ok(model);
        }

        // Writing(Persistence):

        // POST: api/v1/users
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<DtoUser>> Create([FromBody] DtoUser model)
        {
            Logger.LogInformation("UserController.Create: POST: api/v1/users");

            var newModel = await this.appServiceUser.CreateUserAccount(model);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            return Ok(newModel);
        }

        // PUT: api/v1/users/666/activate
        [HttpPut]
        [Route("{id:int}/activate")]
        public async Task<ActionResult<DtoUser>> Activate(int id)
        {
            Logger.LogInformation($"UserController.Activate: PUT: api/v1/users/{id}/activate");

            var model = await this.appServiceUser.ActivateUserAccount((int) id);
            
            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            if (model == null)
                return NotFound("Error: The user not found.");

            return Ok(model);
        }

        // PUT: api/v1/users/666/disable
        [HttpPut]
        [Route("{id:int}/disable")]
        public async Task<ActionResult<DtoUser>> Disable(int id)
        {
            Logger.LogInformation($"UserController.Disable: PUT: api/v1/users/{id}/disable");

            var model = await this.appServiceUser.DisableUserAccount((int) id);
            
            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            if (model == null)
                return NotFound("Error: The user not found.");

            return Ok(model);
        }

        // PUT: api/v1/users/666/block
        [HttpPut]
        [Route("{id:int}/block")]
        public async Task<ActionResult<DtoUser>> Block(int id)
        {
            Logger.LogInformation($"UserController.Block: PUT: api/v1/users/{id}/block");

            var model = await this.appServiceUser.BlockUserAccount((int) id);
            
            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            if (model == null)
                return NotFound("Error: The user not found.");

            return Ok(model);
        }

        // PUT: api/v1/users
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<DtoUser>> Update([FromBody] DtoUser model)
        {
            Logger.LogInformation("UserController.Update: PUT: api/v1/users");

            var updatedModel = await this.appServiceUser.UpdateUserData(model);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            if (updatedModel == null)
                return NotFound("Error: The user not found.");
            
            return Ok(updatedModel);
        }

        // DELETE: api/v1/users/33
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Remove(int? id)
        {
            Logger.LogInformation($"UserController.Remove: DELETE: api/v1/users/{id}");

            if (id == null)
                return BadRequest("Error: The user ID is null!");

            await this.appServiceUser.DeleteUserAccount((int) id);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            return NoContent();
        }

        // PUT: api/v1/users/33
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> ChangePassword(int id, [FromBody] DtoChangePassword model)
        {
            Logger.LogInformation($"UserController.ChangePassword: PUT: api/v1/users/{id}");

            await this.appServiceUser.ChangePasswordFromUserAccount(id, model);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            await this.appServiceUser.ChangePasswordFromUserAccount(id, model);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            await Task.CompletedTask.ConfigureAwait(false);

            return NoContent();
        }

    }
}
