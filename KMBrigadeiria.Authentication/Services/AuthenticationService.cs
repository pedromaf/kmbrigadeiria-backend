using KMBrigadeiria.Authentication.Models;
using KMBrigadeiria.Authentication.Models.Requests;
using Microsoft.AspNetCore.Identity;
using KMBrigadeiria.Authentication.Services.Interfaces;
using KMBrigadeiria.Authentication.Models.Exceptions;

namespace KMBrigadeiria.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly ITokenService _tokenService; 

        public AuthenticationService(SignInManager<IdentityUser<int>> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Token UserLogin(LoginRequest request)
        {
            IdentityUser<int> user = GetUserByUsername(request.Username);

            if (user == null)
            {
                throw new LoginUnauthorizedException();
            }

            string userRole = _signInManager.UserManager.GetRolesAsync(user).Result.FirstOrDefault();

            Login(request.Username, request.Password, false, false);

            return _tokenService.CreateToken(user, userRole);
        }

        public void Logout()
        {
            Task logoutResult = _signInManager.SignOutAsync();

            if (!logoutResult.IsCompletedSuccessfully)
            {
                throw new UserLogoutNotPerformedException();
            }
        }

        private void Login(string username, string password, bool isPersistent, bool lockoutOnFailure)
        {
            Task<SignInResult> signInResult = _signInManager.PasswordSignInAsync(username, password, isPersistent, lockoutOnFailure);

            if (!signInResult.Result.Succeeded)
            {
                throw new LoginUnauthorizedException();
            }
        }

        private IdentityUser<int> GetUserByUsername(string username)
        {
            IdentityUser<int> user = _signInManager.UserManager.Users.FirstOrDefault(
                        usr => usr.NormalizedUserName == username.ToUpper());

            return user;
        }
    }
}
