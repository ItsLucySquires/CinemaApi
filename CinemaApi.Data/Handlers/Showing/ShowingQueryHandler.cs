using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Showing
{
    public record ShowingQuery : IRequest<IReadOnlyList<Models.Showing>>;

    public class ShowingQueryHandler(CinemaApiContext dbContext) : IRequestHandler<ShowingQuery, IReadOnlyList<Models.Showing>>
    {
        public async Task<IReadOnlyList<Models.Showing>> Handle(ShowingQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Showing.ToListAsync();
        }
    }
}
