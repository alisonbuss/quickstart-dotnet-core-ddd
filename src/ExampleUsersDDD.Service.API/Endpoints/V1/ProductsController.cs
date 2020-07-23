
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Service.API.Endpoints.V1
{
    [ApiController]
    [Route("api/v1/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBaseAPI
    {
        private readonly IAppServiceProduct appServiceProduct;

        public ProductsController(
            ILogger<ProductsController> logger, IAppServiceProduct appServiceProduct
        ) : base(logger)
        {
            this.appServiceProduct = appServiceProduct;
        }

        // Private Support Methods:

        private async Task<bool> ModelExists(int id)
        {
            Logger.LogInformation("ProductsController.ModelExists: Call to Method");

            var model = await this.appServiceProduct.GetById((int) id);
            return model != null;
        }

        // Reading(Consultation):

        // GET: api/v1/products
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<DtoProduct>>> ReadAll()
        {
            Logger.LogInformation("ProductsController.ReadAll: GET: api/v1/products");

            // Testing a delay...
            await Task.Delay(3666);
           
            var models = await this.appServiceProduct.GetAll();
            
            return Ok(models);
        }

         // GET: api/v1/products/666
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<DtoProduct>> ReadById(int? id)
        {
            Logger.LogInformation($"ProductsController.ReadById: GET: api/v1/products/{id}");

            if (id == null)
                return BadRequest("Error: The product ID is null!");

            var model = await this.appServiceProduct.GetById((int) id);

            if (model == null)
                return NotFound("Error: The product not found.");

            return Ok(model);
        }

        // Writing(Persistence):

        // POST: api/v1/products
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<DtoProduct>> Create([FromBody] DtoProduct model)
        {
            Logger.LogInformation("ProductsController.Create: POST: api/v1/products");

            var newModel = await this.appServiceProduct.Add(model);

            return Ok(newModel);
        }

        // PUT: api/v1/products
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<DtoProduct>> Update([FromBody] DtoProduct model)
        {
            Logger.LogInformation("ProductsController.Update: PUT: api/v1/products");

            if (!await this.ModelExists(model.Id))
                return NotFound("Error: It was not possible to find the product to perform the update.");
            
            var updatedModel = await this.appServiceProduct.Update(model);
            
            return Ok(updatedModel);
        }

        // DELETE: api/v1/products/33
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Remove(int? id)
        {
            Logger.LogInformation($"ProductsController.Remove: DELETE: api/v1/products/{id}");

            if (id == null)
                return BadRequest("Error: The product ID is null!");

            var currentModel = await this.appServiceProduct.GetById((int) id);

            if (currentModel == null)
                return NotFound("Error: It was not possible to find the product to perform the remove.");
            
            await this.appServiceProduct.Remove(currentModel);

            // return NoContent();
            return Ok("The product has been successfully removed!");
        }

    }
}
