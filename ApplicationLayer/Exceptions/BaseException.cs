

namespace ApplicationLayer.Exceptions
{
    public class BaseException : ApplicationException
    {
        public int ErrorCode { get; set; }
        public BaseException() { }

        public BaseException(string message) : base(message) { }

        public BaseException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public BaseException(string message,Exception innerException) : base(message, innerException) { }

        public BaseException(string message,int errorCode): base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
