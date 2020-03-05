using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Infra.Data.Repositories;
using MoneyAdmin.WebApi.Services;
using MoneyAdmin.WebApi.ViewModels;

namespace MoneyAdmin.WebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = UserRepository.Get(loginViewModel.UserName, loginViewModel.Password);

            if (user == null)
                return BadRequest("Not Found");

            var token = TokenServices.GeneratorToken(user);
            user.Password = "";

            return new OkObjectResult(new { user, token });
        }
    }
}