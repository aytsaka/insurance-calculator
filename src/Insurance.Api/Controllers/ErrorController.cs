using Insurance.Api.ExceptionHandling;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Insurance.Api.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = HttpStatusCode.InternalServerError;

            if (exception is Client.Exceptions.NotFoundException) code = HttpStatusCode.NotFound;
            if (exception is Domain.Exceptions.NotFoundException) code = HttpStatusCode.NotFound;

            Response.StatusCode = (int)code;

            return new ErrorResponse(exception);
        }
    }
}