using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Application.ViewModels;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyAdmin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            try
            {
                return Ok(await _accountRepository.GetAll());
            }
            catch (TimeoutException)
            {
                return new StatusCodeResult(504);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(AccountViewModel accountViewModel)
        {
            await _accountRepository.Add(new Account(accountViewModel.Name));

            return Ok();
        }
    }
}