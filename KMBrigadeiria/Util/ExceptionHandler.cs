using KMBrigadeiria.Models.Exceptions.RepositoryExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KMBrigadeiria.Util
{
    public static class ExceptionHandler
    {
        public static IActionResult HandleException(this ControllerBase controller, Exception exc)
        {
            return exc switch
            {
                EntityNotFoundException => controller.BadRequest(exc.Message),
                _ => controller.StatusCode((int)HttpStatusCode.InternalServerError, exc.Message)
            };
        }
    }
}
