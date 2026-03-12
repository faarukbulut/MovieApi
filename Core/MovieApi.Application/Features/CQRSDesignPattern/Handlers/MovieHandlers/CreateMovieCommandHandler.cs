using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Domain.Entities.Movie
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate,
                CreatedYear = command.CreatedYear,
                Status = command.Status,
                CategoryId = command.CategoryId,
            });

            await _context.SaveChangesAsync();
        }
    }
}
