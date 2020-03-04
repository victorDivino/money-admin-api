using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain.Models;
using MoneyAdmin.Infra.Data.Repositories;
using MoneyAdmin.WebApi.Services;

namespace MoneyAdmin.WebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Login model)
        {
            var user = LoginRepository.Get(model.UserName, model.PassWord);

            if (user == null)
                return BadRequest("Not Found");

            var token = TokenServices.GeneratorToken(user);
            user.PassWord = "";
            return new
            {
                user,
                token
            };
        }
    }
}