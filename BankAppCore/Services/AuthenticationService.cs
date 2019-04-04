using BankAppCore.Data.EFContext;
using BankAppCore.Data.EFContext;
using BankAppCore.DataTranferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankAppCore.Services
{
    public class AuthenticationService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }


        private async Task<List<Claim>> GetValidClaims(ApplicationUser user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
             
        };
            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }


        public async Task<JwtSecurityToken> Login(LoginModel login)
        {

            var result = await signInManager.PasswordSignInAsync(login.Username, login.Password, true, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(login.Username);

                // Get valid claims and pass them into JWT
                var claims = await GetValidClaims(user);


                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.key));
                SigningCredentials creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256.ToString());

                // Create the JWT security token and encode it.
                var token = new JwtSecurityToken(
                    issuer: "http://oec.com", audience: "http://oec.com", expires: DateTime.UtcNow.AddHours(1), claims: claims, signingCredentials: creds);

                return token;
            }
            else
            {
                throw new InvalidOperationException("Wrong username or password");
            }

            /*
            var user = await userManager.FindByNameAsync(login.Username);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };



            if (user != null && await userManager.CheckPasswordAsync(user, login.Password))
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Startup.key));
                SigningCredentials creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256.ToString());
                JwtSecurityToken token = new JwtSecurityToken(issuer: "http://oec.com", audience: "http://oec.com", expires: DateTime.UtcNow.AddHours(1), claims: claims, signingCredentials: creds);
                return token;
            }

        
            throw new InvalidOperationException();*/
        }

      
    }
}
