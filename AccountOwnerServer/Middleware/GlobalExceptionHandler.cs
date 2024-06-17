using Logging.Abstractions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace AccountOwnerServer.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager logger;
        private readonly IHostEnvironment env;

        public GlobalExceptionHandler(IHostEnvironment env, ILoggerManager logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(
                $"An error occurred while processing your request: {exception.Message}");

            var statusCode = httpContext.Response.StatusCode;
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);

            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = "An unhandled exception has occurred while executing the request.";
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = reasonPhrase,
            };

            if (env.IsDevelopment())
            {
                problemDetails.Type = exception.GetType().Name;
                problemDetails.Detail = exception.ToString();
                problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;
            }

            httpContext.Response.ContentType = "application/problem+json";

            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
