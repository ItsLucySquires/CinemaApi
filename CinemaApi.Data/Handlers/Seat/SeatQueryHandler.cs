using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Seat
{
    public record SeatQuery : IRequest<IReadOnlyList<Models.Seat>>;

    public class SeatQueryHandler(CinemaApiContext dbContext) : IRequestHandler<SeatQuery, IReadOnlyList<Models.Seat>>
    {
        public async Task<IReadOnlyList<Models.Seat>> Handle(SeatQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Seat.ToListAsync();
        }
    }
}
