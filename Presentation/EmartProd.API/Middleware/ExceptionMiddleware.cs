using System.Net;
using System.Text.Json;
using EmartProd.API.Responses;

namespace EmartProd.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this._logger = logger;
            this._env = env;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
           try
           {
               await _next(httpContext);
           }
           catch (Exception ex)
           {
              _logger.LogError(ex, ex.Message);
              httpContext.Response.ContentType = "application/json";
              httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

              var response = _env.IsDevelopment() 
              ? new APIException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString()) 
              : new APIException((int)HttpStatusCode.InternalServerError);

              var options = new JsonSerializerOptions{PropertyNamingPolicy= JsonNamingPolicy.CamelCase};

              var json = JsonSerializer.Serialize(response,options);
              await httpContext.Response.WriteAsync(json);

           }
        }
    }
}