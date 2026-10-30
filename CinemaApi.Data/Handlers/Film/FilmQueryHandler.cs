using CinemaApi.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Data.Handlers.Film
{
    public record FilmQuery : IRequest<IReadOnlyList<Models.Film>>;

    public class FilmQueryHandler(CinemaApiContext dbContext) : IRequestHandler<FilmQuery, IReadOnlyList<Models.Film>>
    {
        public async Task<IReadOnlyList<Models.Film>> Handle(FilmQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Film.ToListAsync();
        }
    }
}
