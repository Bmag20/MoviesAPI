namespace MoviesAPI.Server.Command
{
    public interface ICommand
    {
        public Response Execute(Request request);
    }
}