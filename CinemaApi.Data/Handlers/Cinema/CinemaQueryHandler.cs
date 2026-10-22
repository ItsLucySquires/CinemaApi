using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Cinema
{
    public record CinemaQuery : IRequest<IReadOnlyList<Models.Cinema>>;

    public class CinemaQueryHandler(CinemaApiContext dbContext) : IRequestHandler<CinemaQuery, IReadOnlyList<Models.Cinema>>
    {
        public async Task<IReadOnlyList<Models.Cinema>> Handle(CinemaQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Cinema.ToListAsync();
        }
    }
}
