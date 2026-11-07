using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Film
{
    public sealed record FilmSearchQuery(string SearchTerm) : IRequest<IReadOnlyList<Models.Film>>;

    public class FilmSearchQueryHandler(CinemaApiContext dbContext) : IRequestHandler<FilmSearchQuery, IReadOnlyList<Models.Film>>
    {
        public async Task<IReadOnlyList<Models.Film>> Handle(FilmSearchQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Film.Where(f => f.Title.Contains(request.SearchTerm)).ToListAsync();
        }
    }
}
