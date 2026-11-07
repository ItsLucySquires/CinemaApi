using MediatR;
using Microsoft.EntityFrameworkCore;
    
namespace CinemaApi.Data.Handlers.Seat
{
    public sealed record UpdateSeatCommand(System.Guid? id, Models.Seat seat) : IRequest;

    public class UpdateSeatCommandHandler(CinemaApiContext dbContext) : IRequestHandler<UpdateSeatCommand>
    {
        public async Task Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Seat.FirstAsync(p => p.Id == request.seat.Id, cancellationToken);
            entity = request.seat;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
