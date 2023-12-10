

namespace ApplicationLayer.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base("BadRequestException") { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(int errorCode) : base(errorCode)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }

        public BadRequestException(string message, int errorCode) : base(message)
        {
        }
    }
}
