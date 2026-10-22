using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record PostCinemaCommand(Models.Cinema cinema) : IRequest;

    public class PostCinemaCommandHandler(CinemaApiContext dbContext) : IRequestHandler<PostCinemaCommand>
    {
        public async Task Handle(PostCinemaCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Cinema.AddAsync(request.cinema, cancellationToken);             
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
