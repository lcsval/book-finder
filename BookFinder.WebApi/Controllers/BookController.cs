using BookFinder.Application.Book.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BookFinder.WebApi.Controllers
{
    public class BookController : ApiController 
    {
        public BookController(IMediator mediator) : base (mediator)
        {

        }

        [HttpGet]
        [Route("GetBooks")]
        //[ProducesResponseType(typeof(GetBookViewModel), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(GetBookViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetBookViewModel>> GetBooks(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetBookQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
