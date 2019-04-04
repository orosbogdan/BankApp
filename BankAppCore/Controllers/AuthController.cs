using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BankAppCore.Data.EFContext;
using BankAppCore.DataTranferObjects;
using BankAppCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BankAppCore.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private AuthenticationService authenticationService;


        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            authenticationService = new AuthenticationService(userManager,signInManager,roleManager);
        }

        [HttpPost]
        [Authorize(Roles ="employee")]
        [Route("Test")]
        public object Test()
        {
            //list claims
            return User.Claims.Select(c =>
            new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
    
           


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                var token = await authenticationService.Login(login);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            catch
            {
                return Unauthorized();
            }
         
        }
    }
}