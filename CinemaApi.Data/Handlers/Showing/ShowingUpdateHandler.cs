using MediatR;
using Microsoft.EntityFrameworkCore;
    
namespace CinemaApi.Data.Handlers.Showing
{
    public sealed record UpdateShowingCommand(System.Guid? id, Models.Showing showing) : IRequest;

    public class UpdateShowingCommandHandler(CinemaApiContext dbContext) : IRequestHandler<UpdateShowingCommand>
    {
        public async Task Handle(UpdateShowingCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Showing.FirstAsync(p => p.Id == request.showing.Id, cancellationToken);
            entity = request.showing;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
