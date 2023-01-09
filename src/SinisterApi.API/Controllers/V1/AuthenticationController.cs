using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinisterApi.API.Controllers.V1.Base;
using Domain.Core.Infrastructure.Exceptions;
using Infrastruture.CrossCutting.Identity.Configuration;
using Infrastruture.CrossCutting.Identity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace SinisterApi.API.Controllers.V1
{
    public class AuthenticationController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly TokenConfiguration tokenConfiguration;

        public AuthenticationController(IOptions<TokenConfiguration> tokenConfiguration, ILogger<AuthenticationController> logger,
                                        SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.tokenConfiguration = tokenConfiguration.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<ActionResult> TokenRequestAsync(GetTokenModel loginViewModel)
        {
            var request = new { loginViewModel.Login, Password = string.IsNullOrWhiteSpace(loginViewModel.Password) ? "não informada" : new string('*', loginViewModel.Password.Length) };
            try
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Login, loginViewModel.Password, false, true);
                if (result.IsLockedOut)
                {
                    throw new BusinessException("Usuário temporariamente bloqueado por tentativas inválidas.");
                }
                if (result.Succeeded)
                {
                    var jwt = await GerarJwt(loginViewModel.Login);
                    return base.ReturnSuccess(jwt);
                }

                throw new BusinessException("Usuário ou senha incorretos.");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<GetTokenResponseModel> GerarJwt(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            var claims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            claims.Add(new Claim("userId", user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim("userName", user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenConfiguration.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfiguration.Emissor,
                Audience = tokenConfiguration.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(tokenConfiguration.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new GetTokenResponseModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(tokenConfiguration.ExpiracaoHoras).TotalSeconds,
                Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
