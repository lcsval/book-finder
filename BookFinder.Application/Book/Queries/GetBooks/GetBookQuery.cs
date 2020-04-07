using MediatR;

namespace BookFinder.Application.Book.Queries.GetBooks
{
    public class GetBookQuery : IRequest<GetBookViewModel>
    {
        public GetBookQuery()
        {
        }

        public GetBookQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
