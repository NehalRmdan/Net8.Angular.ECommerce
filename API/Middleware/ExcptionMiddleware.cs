using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExcptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

public ExcptionMiddleware(RequestDelegate next, 
        ILogger<ExcptionMiddleware> logger,
        IHostEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try{
               await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response= _environment.IsDevelopment()? 
                                new APIException((int)HttpStatusCode.InternalServerError,ex.Message, ex.StackTrace)
                                : new APIException((int)HttpStatusCode.InternalServerError);
               
               var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
               
               var json= JsonSerializer.Serialize(response, options);

               await context.Response.WriteAsync(json);
            };
        }
    }
}