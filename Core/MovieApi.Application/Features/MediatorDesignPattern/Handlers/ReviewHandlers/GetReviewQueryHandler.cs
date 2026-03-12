using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.ReviewResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.ReviewHandlers
{
    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>
    {
        private readonly MovieContext _context;

        public GetReviewQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Reviews
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new GetReviewQueryResult
                {
                    ReviewId = x.ReviewId,
                    ReviewComment = x.ReviewComment,
                    UserRating = x.UserRating,
                    ReviewDate = x.ReviewDate,
                    Status = x.Status,
                    UserId = x.UserId,
                    MovieId = x.MovieId,
                    IsSpoiler = x.IsSpoiler,
                    LikeCount = x.LikeCount,
                    SentimentScore = x.SentimentScore
                }).ToListAsync();

            return values;
        }
    }
}
