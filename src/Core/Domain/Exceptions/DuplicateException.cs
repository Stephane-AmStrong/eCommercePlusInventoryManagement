namespace Domain.Exceptions
{
    public abstract class DuplicateException : Exception
    {
        protected DuplicateException(string message) : base(message)
        {
        }
    }
}
