namespace VEZEETA.API.Models
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
        public string Details { get; set; } = null!;

        public override string ToString()
        {
            return $"StatusCode: {StatusCode}\nMessage: {Message}\nDetails: {Details}\n";
        }
    }
}
