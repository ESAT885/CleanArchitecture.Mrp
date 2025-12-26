using CleanArchitecture.Mrp.Api.Models.BaseModels;
using CleanArchitecture.Mrp.Application.Exceptions;
using FluentValidation;

namespace CleanArchitecture.Mrp.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var traceId = context.TraceIdentifier;
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogWarning(
                   ex,
                   "Application exception | TraceId: {TraceId} | Detail: {Detail}",
                   traceId,
                    ex.Message
                 );
                var clientMessage = _env.IsProduction()
               ? "Bir hata oluştu"
               : ex.PublicMessage;
                await WriteResponse(
                context,
                ex.StatusCode,
                clientMessage,
                traceId
                 );
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(
                   ex,
                   "Validation exception | TraceId: {TraceId} | Detail: {Detail}",
                   traceId,
                    ex.Message
                 );
                var errors = ex.Errors
              .GroupBy(e => e.PropertyName)
              .ToDictionary(
                  g => g.Key,
                  g => g.Select(e => e.ErrorMessage).ToArray()
              );

                var clientMessage =
              "Bir hata oluştu";
              
                await WriteResponse(
                context,
                 StatusCodes.Status400BadRequest,
                "Bir hata oluştu",
                traceId,
                errors
                 );
            }
            catch (Exception ex)
            {


                _logger.LogError(
                    ex,
                    "Unhandled exception | traceId: {traceId}",
                    traceId);

                await WriteResponse(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Beklenmeyen bir hata oluştu",
                    traceId
                );
            }
        }

        private static async Task WriteResponse(
            HttpContext context,
            int statusCode,
            string message,
            string traceId,
             Dictionary<string, string[]>? errors = null
            )
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.Fail(message, traceId, errors);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
