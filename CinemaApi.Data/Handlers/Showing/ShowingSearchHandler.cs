using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Showing
{
    public sealed record ShowingSearchQuery(DateTime SearchTerm) : IRequest<IReadOnlyList<Models.Showing>>;

    public class ShowingSearchQueryHandler(CinemaApiContext dbContext) : IRequestHandler<ShowingSearchQuery, IReadOnlyList<Models.Showing>>
    {
        public async Task<IReadOnlyList<Models.Showing>> Handle(ShowingSearchQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Showing.Where(s => s.StartTime >= request.SearchTerm).ToListAsync();
        }
    }
}
