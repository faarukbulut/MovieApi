using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public int CastId { get; set; }

        public RemoveCastCommand(int castId)
        {
            CastId = castId;
        }
    }
}
