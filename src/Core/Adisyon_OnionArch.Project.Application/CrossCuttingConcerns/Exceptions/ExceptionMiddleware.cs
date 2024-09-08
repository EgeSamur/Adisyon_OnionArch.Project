using Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Logging.LogFormats;
using Adisyon_OnionArch.Project.Application.Interfaces.Logger;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILoggerCustom _loggerService;
        private readonly IUnitOfWork _unitOfWork;



        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public ExceptionMiddleware(ILoggerCustom loggerService, IUnitOfWork unitOfWork)
        {
            _loggerService = loggerService;
            _unitOfWork = unitOfWork;

            // JsonSerializerOptions yapılandırması
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true, // Logları daha okunabilir hale getirir,
            };
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);  // Request'i bir sonraki middleware'e gönder
            }
            catch (Exception ex)
            {
                await HandleLog(httpContext, ex);
                // exception handler 
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private async Task HandleLog(HttpContext httpContext, Exception ex)
        {
            string reqBody = await GetRequestBody(httpContext);
            // Loglama
            var logDetail = new LogDetailWithException
            {
                Id = Guid.NewGuid(),
                TraceId = httpContext.TraceIdentifier,
                LogType = "Error",
                Path = httpContext.Request.Path,
                Query = httpContext.Request.Query.ToString(),
                Header = httpContext.Request.Headers.ToString(),
                RequestBody = reqBody,
                ResponseBody = "",
                StatusCode = GetStatusCode(ex),
                HttpMethod = httpContext.Request.Method,
                IpAddress = httpContext.Connection.RemoteIpAddress?.ToString(),
                LogDate = DateTime.UtcNow,
                User = httpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "?",
                Detail = ex.Message,
                Exception = ex.ToString(),
                StackTrace = ex.StackTrace
            };

            _loggerService.Error(JsonSerializer.Serialize(logDetail));
            await _unitOfWork.GetWriteRepository<LogDetailWithException>().AddAsync(logDetail);
            await _unitOfWork.SaveAsync();

        }

        private static async Task<string> GetRequestBody(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            httpContext.Request.Body.Position = 0;
            using var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, leaveOpen: true);
            string content = await reader.ReadToEndAsync();
            httpContext.Request.Body.Position = 0;
            return content;
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(
                    new ExceptionModel
                    {
                        Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                        StatusCode = StatusCodes.Status400BadRequest
                    }.ToString());
            }

            List<string> errors = new()
            {
                exception.Message,
            };
            var y = new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode

            }.ToString();
            var x = httpContext.Response.WriteAsync(y);
            return x;
        }

        private static int GetStatusCode(Exception exception) =>

            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

    }
}
