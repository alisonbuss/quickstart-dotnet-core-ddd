
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleUsersDDD.Service.API.Endpoints
{
    [ApiController]
    public abstract class ControllerBaseAPI : ControllerBase
    {
        public ControllerBaseAPI(ILogger<ControllerBaseAPI> logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; private set; }

    }
}