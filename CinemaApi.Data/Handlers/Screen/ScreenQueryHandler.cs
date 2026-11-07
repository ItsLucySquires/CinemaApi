using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Screen
{
    public record ScreenQuery : IRequest<IReadOnlyList<Models.Screen>>;

    public class ScreenQueryHandler(CinemaApiContext dbContext) : IRequestHandler<ScreenQuery, IReadOnlyList<Models.Screen>>
    {
        public async Task<IReadOnlyList<Models.Screen>> Handle(ScreenQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Screen.ToListAsync();
        }
    }
}
