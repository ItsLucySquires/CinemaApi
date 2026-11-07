using MediatR;

namespace CinemaApi.Data.Handlers.Screen
{
    public sealed record DeleteScreenCommand(Guid id) : IRequest;

    public class ScreenDeleteCommandHandler(CinemaApiContext dbContext) : IRequestHandler<DeleteScreenCommand>
    {
        public async Task Handle(DeleteScreenCommand request, CancellationToken cancellationToken)
        {
            var screen = await dbContext.Screen.FindAsync(request.id, cancellationToken);
            if (screen == null)
            {
                throw new InvalidOperationException("Screen not found");
            }

            dbContext.Screen.Remove(screen);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
