using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShgEcom.Application.Common.Errors;

namespace ShgEcom.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, exception?.Message)
            };
            return Problem(title: message, statusCode: statusCode);
        }
    }
}
