using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyAdmin.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _bus;
        private readonly IAccountRepositoryReadOnly _accountRepositoryReadOnly;

        public AccountController(IMediator bus, IAccountRepositoryReadOnly accountRepositoryReadOnly)
        {
            _bus = bus;
            _accountRepositoryReadOnly = accountRepositoryReadOnly;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            try
            {
                return Ok(_accountRepositoryReadOnly.GetAll().ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountCommand createAccountCommand)
        {
            try
            {
                await _bus.Send(createAccountCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
