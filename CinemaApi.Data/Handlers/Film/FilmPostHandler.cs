using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Handlers.Film
{
    public sealed record PostFilmCommand(Models.Film film) : IRequest;

    public class PostFilmCommandHandler(CinemaApiContext dbContext) : IRequestHandler<PostFilmCommand>
    {
        public async Task Handle(PostFilmCommand request, CancellationToken cancellationToken)
        {
            await dbContext.Film.AddAsync(request.film, cancellationToken);             
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
