using KMBrigadeiria.Authentication.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KMBrigadeiria.Authentication.Util
{
    public static class ExceptionHandler
    {
        public static IActionResult HandleException(this ControllerBase controller, Exception exc)
        {
            return exc switch
            {
                LoginUnauthorizedException => UnauthorizedResult(controller, exc),
                UserLogoutNotPerformedException => InternalServerErrorResult(controller, exc),
                _ => InternalServerErrorResult(controller, exc)
            };
        }

        private static IActionResult InternalServerErrorResult(ControllerBase controller, Exception exc)
        {
            return controller.StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
        }
        private static IActionResult UnauthorizedResult(ControllerBase controller, Exception exc)
        {
            return controller.Unauthorized(exc.Message);
        }
    }
}
