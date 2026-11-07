using MediatR;

namespace CinemaApi.Data.Handlers.Seat
{
    public sealed record DeleteSeatCommand(Guid id) : IRequest;

    public class SeatDeleteCommandHandler(CinemaApiContext dbContext) : IRequestHandler<DeleteSeatCommand>
    {
        public async Task Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = await dbContext.Seat.FindAsync(request.id, cancellationToken);
            if (seat == null)
            {
                throw new InvalidOperationException("Seat not found");
            }

            dbContext.Seat.Remove(seat);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
