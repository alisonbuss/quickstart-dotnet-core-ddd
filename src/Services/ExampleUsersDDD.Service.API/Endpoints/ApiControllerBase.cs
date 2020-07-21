
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleUsersDDD.Service.API.Endpoints
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiControllerBase(ILogger<ApiControllerBase> logger)
        {
            _logger = logger;
        }


    }
}