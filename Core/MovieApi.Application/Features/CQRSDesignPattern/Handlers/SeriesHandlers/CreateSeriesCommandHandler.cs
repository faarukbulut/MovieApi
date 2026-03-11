using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
        private readonly MovieContext _context;

        public CreateSeriesCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSeriesCommand command)
        {
            _context.Serieses.Add(new Domain.Entities.Series
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                CreatedYear = command.CreatedYear,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                Status = command.Status,
                CategoryId = command.CategoryId,
            });

            await _context.SaveChangesAsync();
        }
    }
}
