using KMBrigadeiria.Authentication.Models;
using KMBrigadeiria.Authentication.Models.Requests;
using KMBrigadeiria.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KMBrigadeiria.Authentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService service)
        {
            _authenticationService = service;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Token token = _authenticationService.UserLogin(request);

                return Ok(token);
            }
            catch (Exception exc) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exc.Message);
            }
        }
    }
}
