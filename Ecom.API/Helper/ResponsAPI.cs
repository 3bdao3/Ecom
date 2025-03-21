namespace Ecom.API.Helper
{
    public class ResponsAPI
    {
        public ResponsAPI(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message?? GetmessageFromStatusCode(StatusCode);
        }
        private string GetmessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Don",
                400=> "Bad Request",
                401 => "Unauthorized",
                500 => "Internal Server Error",
                _ => null,

            };
        }
        public int StatusCode { get; set; } 
        public string? Message { get; set; }
    }
}
