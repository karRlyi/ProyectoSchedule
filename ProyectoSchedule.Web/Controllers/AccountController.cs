namespace ProyectoSchedule.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using ProyectoSchedule.Web.Helpers;
    using ProyectoSchedule.Web.Models;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly IConfiguration configuration;

        public AccountController(IUserHelper userHelper, IConfiguration configuration)
        {
            this.userHelper = userHelper;
            this.configuration = configuration;
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var resullt = await this.userHelper.LoginAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe);

            if (resullt.Succeeded)
            {
                if (this.Request.Query.Keys.Contains("Return Url"))
                {
                    return this.Redirect(this.Request.Query["Return Url"].First());
                }
                return this.RedirectToAction("Index", "Home");
            }
            this.ModelState.AddModelError(string.Empty, "Falló tu Login");
            return this.View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]

        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.UserName);
                if (user != null)
                {
                    var result = await this.userHelper.ValidatePasswordAsync(user, model.Password);
                    if(result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Key"]));
                        var Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var Token = new JwtSecurityToken(
                            this.configuration["Tokens:Issuer"], 
                            this.configuration["Tokens:Audience"],
                            claims,
                            expires:DateTime.UtcNow.AddSeconds(30),
                            signingCredentials:Credentials);
                        var results = new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(Token),
                            expiration = Token.ValidTo
                        };
                        return this.Created(string.Empty, results);
                    }
                }
            }
            return this.BadRequest();
        }
    }
}
