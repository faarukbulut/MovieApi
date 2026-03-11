using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            await _context.Casts.AddAsync(new Cast
            {
                Title = request.Title,
                Name = request.Name,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                Overview = request.Overview,
                Biography = request.Biography,
            });

            await _context.SaveChangesAsync();
        }
    }
}