using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Handlers.Showing
{
    public sealed record PostShowingCommand(Models.Showing showing) : IRequest;

    public class PostShowingCommandHandler(CinemaApiContext dbContext) : IRequestHandler<PostShowingCommand>
    {
        public async Task Handle(PostShowingCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Showing.AddAsync(request.showing, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
