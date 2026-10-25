using MediatR;

namespace CinemaApi.Data.Handlers.Film
{
    public sealed record DeleteFilmCommand(Guid id) : IRequest;

    public class FilmDeleteCommandHandler(CinemaApiContext dbContext) : IRequestHandler<DeleteFilmCommand>
    {
        public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await dbContext.Film.FindAsync(request.id, cancellationToken);
            if (film == null)
            {
                throw new InvalidOperationException("Film not found");
            }

            dbContext.Film.Remove(film);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
