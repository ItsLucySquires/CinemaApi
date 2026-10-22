using MediatR;
using Microsoft.EntityFrameworkCore;
    
namespace CinemaApi.Data.Handlers.Cinema
{
    public sealed record UpdateCinemaCommand(System.Guid? id, Models.Cinema cinema) : IRequest;

    public class UpdatePersonAgeCommandHandler(CinemaApiContext dbContext) : IRequestHandler<UpdateCinemaCommand>
    {
        public async Task Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Cinema.FirstAsync(p => p.Id == request.cinema.Id, cancellationToken);
            entity = request.cinema;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
