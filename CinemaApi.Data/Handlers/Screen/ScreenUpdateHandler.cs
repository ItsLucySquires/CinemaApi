using MediatR;
using Microsoft.EntityFrameworkCore;
    
namespace CinemaApi.Data.Handlers.Screen    
{
    public sealed record UpdateScreenCommand(System.Guid? id, Models.Screen screen) : IRequest;

    public class UpdateScreenCommandHandler(CinemaApiContext dbContext) : IRequestHandler<UpdateScreenCommand>
    {
        public async Task Handle(UpdateScreenCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Screen.FirstAsync(s => s.Id == request.screen.Id, cancellationToken);
            entity = request.screen;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
