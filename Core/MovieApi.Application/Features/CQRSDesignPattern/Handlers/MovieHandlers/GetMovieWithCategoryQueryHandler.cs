using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieWithCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieWithCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
        {
            var values = await _context.Movies.Include(y => y.Category).ToListAsync();

            return values.Select(x => new GetMovieWithCategoryQueryResult
            {
                MovieId = x.MovieId,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                CreatedYear = x.CreatedYear,
                Status = x.Status,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.CategoryName
            }).ToList();
        }
    }
}
