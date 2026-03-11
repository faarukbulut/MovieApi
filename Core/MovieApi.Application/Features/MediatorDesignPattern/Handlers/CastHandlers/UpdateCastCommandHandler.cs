using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;

        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);

            values.Title = request.Title;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.ImageUrl = request.ImageUrl;
            values.Overview = request.Overview;
            values.Biography = request.Biography;

            await _context.SaveChangesAsync();
        }
    }
}

