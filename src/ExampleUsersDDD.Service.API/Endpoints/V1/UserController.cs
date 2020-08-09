
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;
using System.Text.Json;

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

        // private async Task<bool> ModelExists(int id)
        // {
        //     Logger.LogInformation("UserController.ModelExists: Call to Method");

        //     var model = await this.appServiceUser.GetById((int) id);
        //     return model != null;
        // }

        // Reading(Consultation):

        // GET: api/v1/products
        // [HttpGet]
        // [Route("")]
        // public async Task<ActionResult<IEnumerable<DtoProduct>>> ReadAll()
        // {
        //     Logger.LogInformation("UserController.ReadAll: GET: api/v1/products");

        //     // Testing a delay...
        //     await Task.Delay(3666);
           
        //     var models = await this.appServiceProduct.GetAll();
            
        //     return Ok(models);
        // }

         // GET: api/v1/products/666
        // [HttpGet]
        // [Route("{id:int}")]
        // public async Task<ActionResult<DtoProduct>> ReadById(int? id)
        // {
        //     Logger.LogInformation($"UserController.ReadById: GET: api/v1/products/{id}");

        //     if (id == null)
        //         return BadRequest("Error: The product ID is null!");

        //     var model = await this.appServiceProduct.GetById((int) id);

        //     if (model == null)
        //         return NotFound("Error: The product not found.");

        //     return Ok(model);
        // }

        // Writing(Persistence):

        // POST: api/v1/products
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<DtoUser>> Create([FromBody] DtoUser model)
        {
            Logger.LogInformation("UserController.Create: POST: api/v1/products");

            var newModel = await this.appServiceUser.CreateUserAccount(model);

            if(this.appServiceUser.HasNotifications())
                return BadRequest(this.appServiceUser.Notifications());

            return Ok(newModel);
        }

        // PUT: api/v1/products
        // [HttpPut]
        // [Route("")]
        // public async Task<ActionResult<DtoProduct>> Update([FromBody] DtoProduct model)
        // {
        //     Logger.LogInformation("UserController.Update: PUT: api/v1/products");

        //     if (!await this.ModelExists(model.Id))
        //         return NotFound("Error: It was not possible to find the product to perform the update.");
            
        //     var updatedModel = await this.appServiceProduct.Update(model);
            
        //     return Ok(updatedModel);
        // }

        // DELETE: api/v1/products/33
        // [HttpDelete]
        // [Route("{id:int}")]
        // public async Task<ActionResult> Remove(int? id)
        // {
        //     Logger.LogInformation($"UserController.Remove: DELETE: api/v1/products/{id}");

        //     if (id == null)
        //         return BadRequest("Error: The product ID is null!");

        //     var currentModel = await this.appServiceProduct.GetById((int) id);

        //     if (currentModel == null)
        //         return NotFound("Error: It was not possible to find the product to perform the remove.");
            
        //     await this.appServiceProduct.Remove(currentModel);

        //     // return NoContent();
        //     return Ok("The product has been successfully removed!");
        // }

    }
}
