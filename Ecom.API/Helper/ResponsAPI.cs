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
                400 => "Bad Request - الطلب غير صحيح",
                401 => "Unauthorized - غير مصرح لك بالوصول",
                403 => "Forbidden - الوصول مرفوض",
                404 => "Not Found - لم يتم العثور على المورد المطلوب",
                405 => "Method Not Allowed - الطريقة غير مسموحة",
                500 => "Internal Server Error - خطأ داخلي في الخادم",
                502 => "Bad Gateway - بوابة غير صالحة",
                503 => "Service Unavailable - الخدمة غير متوفرة حاليًا",
                _ => "Unexpected Error - حدث خطأ غير متوقع"

            };
        }
        public int StatusCode { get; set; } 
        public string? Message { get; set; }
    }
}
