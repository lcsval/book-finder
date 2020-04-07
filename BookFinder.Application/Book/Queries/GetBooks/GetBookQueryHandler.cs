using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookFinder.Application.Book.Queries.GetBooks
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, GetBookViewModel>
    {
        public GetBookQueryHandler()
        {

        }

        public async Task<GetBookViewModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var x = request;

            return null;
        }
    }
}
