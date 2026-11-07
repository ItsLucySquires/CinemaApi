using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Screen
{
    public sealed record ScreenSearchQuery(string SearchTerm) : IRequest<IReadOnlyList<Models.Screen>>;

    public class ScreenSearchQueryHandler(CinemaApiContext dbContext) : IRequestHandler<ScreenSearchQuery, IReadOnlyList<Models.Screen>>
    {
        public async Task<IReadOnlyList<Models.Screen>> Handle(ScreenSearchQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Screen.Where(s => s.Name.Contains(request.SearchTerm)).ToListAsync();
        }
    }
}
