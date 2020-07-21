
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using ExampleUsersDDD.Application.Dtos;
using ExampleUsersDDD.Application.Interfaces;

using Microsoft.Extensions.Logging;

namespace ExampleUsersDDD.Service.API.Endpoints.V1
{
    [ApiController]
    [Route("api/v1/products")]
    [Produces("application/json")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IAppServiceProduct _appServiceProduct;

        public ProductsController(ILogger<ProductsController> logger, IAppServiceProduct appServiceProduct) : base(logger)
        {
            _appServiceProduct = appServiceProduct;
        }

        // Private Support Methods:

        private async Task<bool> ModelExists(int id)
        {
            var model = await _appServiceProduct.GetById((int) id);
            return model != null;
        }

        // Reading(Consultation):

        // GET: api/v1/products
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<DtoProduct>>> ReadAll()
        {
            _logger.LogInformation("dsdasdsadsad########################### ##########################");

            // Test:
            await Task.Delay(1000);

            var models = await _appServiceProduct.GetAll();
            
            return Ok(models);
        }

         // GET: api/v1/products/666
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<DtoProduct>> ReadById(int? id)
        {
            if (id == null)
                return BadRequest("Error: The product ID is null!");

            var model = await _appServiceProduct.GetById((int) id);

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
            var newModel = await _appServiceProduct.Add(model);

            return Ok(newModel);
        }

        // PUT: api/v1/products
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<DtoProduct>> Update([FromBody] DtoProduct model)
        {
            if (!await this.ModelExists(model.Id))
                return NotFound("Error: It was not possible to find the product to perform the update.");
            
            var updatedModel = await _appServiceProduct.Update(model);
            
            return Ok(updatedModel);
        }

        // DELETE: api/v1/products/33
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Remove(int? id)
        {
            if (id == null)
                return BadRequest("Error: The product ID is null!");

            var currentModel = await _appServiceProduct.GetById((int) id);

            if (currentModel == null)
                return NotFound("Error: It was not possible to find the product to perform the remove.");
            
            await _appServiceProduct.Remove(currentModel);

            // return NoContent();
            return Ok("The product has been successfully removed!");
        }

    }
}
