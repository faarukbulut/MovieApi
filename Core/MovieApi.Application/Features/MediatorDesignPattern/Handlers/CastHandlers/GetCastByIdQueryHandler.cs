using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);

            return new GetCastByIdQueryResult
            {
                CastId = values.CastId,
                Title = values.Title,
                Name = values.Name,
                Surname = values.Surname,
                ImageUrl = values.ImageUrl,
                Overview = values.Overview,
                Biography = values.Biography,
            };
        }
    }
}
