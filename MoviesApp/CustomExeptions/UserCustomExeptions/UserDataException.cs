namespace CustomExceptions.UserCustomExeptions
{
    public class UserDataException : Exception
    {
        public UserDataException(string message) : base(message) { }
    }
}
