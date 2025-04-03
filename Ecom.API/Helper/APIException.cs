namespace Ecom.API.Helper
{
    public class APIException : ResponsAPI
    {
        public APIException(int statusCode, string message = null,string detalis=null) : base(statusCode, message)
        {
            Detalis= detalis;
        }
        public string Detalis { get; set; }
    }
}
