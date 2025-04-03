using System.Net;
using System.Text.Json;
using Ecom.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Ecom.API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
       // private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostingEnvironment _environment;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _reltivtimeSpan = TimeSpan.FromSeconds(30);
        public ExceptionMiddleware(RequestDelegate next, /*ILogger<ExceptionMiddleware> logger*/ IHostingEnvironment _environment, IMemoryCache cache)
        {
            _next = next;
            //_logger = logger;
            this._environment = _environment;
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                ApplySecurity(context);
                if (!IsAPIException(context))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = new APIException((int)HttpStatusCode.TooManyRequests, "Too Many Requests");
                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                    return;
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = _environment.IsDevelopment() ? 
                    new APIException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace)
                    : new APIException((int)HttpStatusCode.InternalServerError, ex.Message);

                var json = JsonSerializer.Serialize(response);
               await context.Response.WriteAsync(json);

            }
        }

        private bool IsAPIException(HttpContext Context)
        {
            var ip= Context.Connection.RemoteIpAddress.ToString();
            var cahkey=$"Rate:{ip}";
            var  dateNow=DateTime.Now;
            var (timestap, count) = _cache.GetOrCreate(cahkey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _reltivtimeSpan;

                return (timestap:dateNow,count: 0);
            });
            if(dateNow- timestap < _reltivtimeSpan)
            {
                if(count >= 8)
                {
                    return false;
                }
                _cache.Set(cahkey, (timestap, count+=1), _reltivtimeSpan);
            }
            else
            {
                _cache.Set(cahkey, (timestap, count ), _reltivtimeSpan);
            }
            return true;
        }


        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
        }


    }

}
