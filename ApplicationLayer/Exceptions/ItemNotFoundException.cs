

namespace ApplicationLayer.Exceptions
{
    public class ItemNotFoundException : BaseException
    {
        public ItemNotFoundException() : base("ItemNotFoundException") { }

        public ItemNotFoundException(string message) : base(message) { }

        public ItemNotFoundException(int errorCode) : base(errorCode)
        {
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public ItemNotFoundException(string message, int errorCode) : base(message)
        {
        }
    }
}
