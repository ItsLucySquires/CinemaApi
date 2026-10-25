using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record CinemaSearchQuery(string SearchTerm) : IRequest<IReadOnlyList<Models.Cinema>>;

    public class CinemaSearchQueryHandler(CinemaApiContext dbContext) : IRequestHandler<CinemaSearchQuery, IReadOnlyList<Models.Cinema>>
    {
        public async Task<IReadOnlyList<Models.Cinema>> Handle(CinemaSearchQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Cinema.ToListAsync();
        }
    }
}
