using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Results
{
    public static class ApiResults
    {
        public static IActionResult Problem(Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException();
            }
            return new ObjectResult(new ProblemDetails
            {
                Title = GetTitle(result.Error),
                Detail = GetDetail(result.Error),
                Type = GetType(result.Error),
                Status = GetStatusCode(result.Error.Type),
                Extensions = { ["Errors"] = GetErrors(result) }
            })
            {
                StatusCode = GetStatusCode(result.Error.Type)
            };
        }


        private static string GetTitle(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => error.Code,
                ErrorType.Problem => error.Code,
                ErrorType.NotFound => error.Code,
                ErrorType.Conflict => error.Code,
                _ => "Server failure"
            };

        private static string GetDetail(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => error.Description,
                ErrorType.Problem => error.Description,
                ErrorType.NotFound => error.Description,
                ErrorType.Conflict => error.Description,
                _ => "Server failure"
            };

        private static string GetType(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.Problem => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                _ => "Server failure"
            };

        private static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Problem => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        private static IDictionary<string, object?>? GetErrors(Result result)
        {
            if (result.Error.Type is not ErrorType.Validation)
                return null;

            return new Dictionary<string, object?>
            {
                { "Error", result.Error },
            };
        }
    }
}
