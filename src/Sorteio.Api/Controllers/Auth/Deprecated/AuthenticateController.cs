using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sorteio.Api.Auth;
using Sorteio.Api.Models.Auth.Deprecated;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sorteio.Api.Controllers.Auth.Deprecated
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticateController(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserViewModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists is not null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseViewModel { Success = false, Message = "Usuário já existe!" }
                );

            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseViewModel { Success = false, Message = "Erro ao criar usuário" }
                );

            var role = model.IsAdmin ? UserRoles.Admin : UserRoles.User;

            await AddToRoleAsync(user, role);

            var claims = await RetornaClaims(user.Email, model.Password);

            TokenViewModel token;
            if (claims != null)
                token = GetToken(claims);
            else
                return Unauthorized();

            return Ok(new ResponseViewModel { Message = "Usuário criado com sucesso!", Data = token });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            var authClaims = await RetornaClaims(model.UserName, model.Password);

            TokenViewModel token;
            if (authClaims != null)
                return Ok(new ResponseViewModel { Data = GetToken(authClaims) });
            else
                return Unauthorized();

        }

        private TokenViewModel GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };

        }

        private async Task AddToRoleAsync(IdentityUser user, string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new(role));

            await _userManager.AddToRoleAsync(user, role);
        }


        private async Task<List<Claim>> RetornaClaims(string userLogin, string password)
        {

            var authClaims = new List<Claim>();
            var user = await _userManager.FindByNameAsync(userLogin);

            if (user is not null && await _userManager.CheckPasswordAsync(user, password))
            {

                authClaims.Add(new(ClaimTypes.Name, user.UserName));
                authClaims.Add(new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var userRole in userRoles)
                    authClaims.Add(new(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }
    }
}
