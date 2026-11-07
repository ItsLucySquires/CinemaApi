using MediatR;

namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record DeleteShowingCommand(Guid id) : IRequest;

    public class ShowingDeleteCommandHandler(CinemaApiContext dbContext) : IRequestHandler<DeleteShowingCommand>
    {
        public async Task Handle(DeleteShowingCommand request, CancellationToken cancellationToken)
        {
            var showing = await dbContext.Showing.FindAsync(request.id, cancellationToken);
            if (showing == null)
            {
                throw new InvalidOperationException("Showing not found");
            }

            dbContext.Showing.Remove(showing);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
