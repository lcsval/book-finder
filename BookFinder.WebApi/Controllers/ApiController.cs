using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookFinder.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public abstract class ApiController : ControllerBase
    {
        protected IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
