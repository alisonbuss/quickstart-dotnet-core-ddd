
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleUsersDDD.Service.API.Endpoints
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        public ApiControllerBase(ILogger<ApiControllerBase> logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; private set; }

    }
}