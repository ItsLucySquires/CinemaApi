using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Handlers.Screen
{
    public sealed record PostScreenCommand(Models.Screen screen) : IRequest;

    public class PostScreenCommandHandler(CinemaApiContext dbContext) : IRequestHandler<PostScreenCommand>
    {
        public async Task Handle(PostScreenCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Screen.AddAsync(request.screen, cancellationToken);             
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
