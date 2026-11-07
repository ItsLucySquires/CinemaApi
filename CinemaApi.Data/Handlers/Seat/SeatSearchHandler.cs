using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Seat
{
    public sealed record SeatSearchQuery(Guid Id) : IRequest<IReadOnlyList<Models.Seat>>;

    public class SeatSearchQueryHandler(CinemaApiContext dbContext) : IRequestHandler<SeatSearchQuery, IReadOnlyList<Models.Seat>>
    {
        public async Task<IReadOnlyList<Models.Seat>> Handle(SeatSearchQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Seat.Where(s => s.Id == request.Id).ToListAsync();
        }
    }
}
