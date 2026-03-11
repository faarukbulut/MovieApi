using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync(query.MovieId);

            return new GetMovieByIdQueryResult
            {
                MovieId = value.MovieId,
                Title = value.Title,
                CoverImageUrl = value.CoverImageUrl,
                Rating = value.Rating,
                Description = value.Description,
                Duration = value.Duration,
                ReleaseDate = value.ReleaseDate,
                CreatedYear = value.CreatedYear,
                Status = value.Status
            };
        }
    }
}
