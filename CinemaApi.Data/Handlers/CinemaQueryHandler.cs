using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers
{
    public sealed record CinemaQuery : IRequest<IReadOnlyList<Cinema>>;

    public class CinemaQueryHandler(CinemaApiContext dbContext) : IRequestHandler<CinemaQuery, IReadOnlyList<Cinema>>
    {
        public async Task<IReadOnlyList<Cinema>> Handle(CinemaQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Cinema.ToListAsync();
        }
    }
}
