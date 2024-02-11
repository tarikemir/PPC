namespace YetDit.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException() : base("Login credentials are incorrect!")
        {

        }

        public NotFoundUserException(string errorMessage) : base(errorMessage) { }
    }
}
