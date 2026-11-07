using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Handlers.Seat
{
    public sealed record PostSeatCommand(Models.Seat seat) : IRequest;

    public class PostSeatCommandHandler(CinemaApiContext dbContext) : IRequestHandler<PostSeatCommand>
    {
        public async Task Handle(PostSeatCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Seat.AddAsync(request.seat, cancellationToken);             
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
