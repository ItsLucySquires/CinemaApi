using MediatR;

namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record DeleteCinemaCommand(Guid id) : IRequest;

    public class CinemaDeleteCommandHandler(CinemaApiContext dbContext) : IRequestHandler<DeleteCinemaCommand>
    {
        public async Task Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await dbContext.Cinema.FindAsync(request.id, cancellationToken);
            if (cinema == null)
            {
                throw new InvalidOperationException("Cinema not found");
            }

            dbContext.Cinema.Remove(cinema);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
