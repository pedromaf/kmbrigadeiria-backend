using KMBrigadeiria.Authentication.Models;
using KMBrigadeiria.Authentication.Models.Requests;
using KMBrigadeiria.Authentication.Services.Interfaces;
using KMBrigadeiria.Authentication.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                Token token = _authenticationService.UserLogin(request);

                return Ok(token);
            }
            catch (Exception exc) 
            {
                return this.HandleException(exc);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                _authenticationService.Logout();

                return Ok();
            }
            catch (Exception exc)
            {
                return this.HandleException(exc);
            }
        }
    }
}
