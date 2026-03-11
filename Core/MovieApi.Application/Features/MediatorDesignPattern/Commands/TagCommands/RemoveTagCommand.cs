using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {
        public int TagId { get; set; }

        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
