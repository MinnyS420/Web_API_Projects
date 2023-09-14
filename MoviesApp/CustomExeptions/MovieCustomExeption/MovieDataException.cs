namespace CustomExeptions
{
    public class MovieDataException : Exception
    {
        public MovieDataException() : base("Generic Movie Data exception occurred.") { }
        public MovieDataException(string message) : base(message) { }
    }
}
