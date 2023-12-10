

namespace ApplicationLayer.Exceptions
{
    public class ItemAlreadyExistException : BaseException
    {
        public ItemAlreadyExistException() : base("ItemAlreadyExistException") { }

        public ItemAlreadyExistException(string message) : base(message) { }

        public ItemAlreadyExistException(int errorCode) : base(errorCode)
        {
        }

        public ItemAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }

        public ItemAlreadyExistException(string message, int errorCode) : base(message)
        {
        }
    }
}
