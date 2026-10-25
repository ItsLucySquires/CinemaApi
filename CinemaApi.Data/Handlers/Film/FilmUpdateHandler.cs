using MediatR;
using Microsoft.EntityFrameworkCore;
    
namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record UpdateFilmCommand(System.Guid? id, Models.Film film) : IRequest;

    public class UpdateFilmCommandHandler(CinemaApiContext dbContext) : IRequestHandler<UpdateFilmCommand>
    {
        public async Task Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Film.FirstAsync(p => p.Id == request.film.Id, cancellationToken);
            entity = request.film;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
