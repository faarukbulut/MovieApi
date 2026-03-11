namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public int MovieId { get; set; }

        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}
