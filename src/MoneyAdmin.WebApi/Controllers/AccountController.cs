using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : CustomController
    {
        private readonly IMediator _mediator;
        private readonly IAccountRepositoryReadOnly _accountRepositoryReadOnly;

        public AccountController(IMediator mediator, IAccountRepositoryReadOnly accountRepositoryReadOnly)
            : base(mediator)
        {
            _mediator = mediator;
            _accountRepositoryReadOnly = accountRepositoryReadOnly;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BankAccount>> Get()
        {
            try
            {
                return Ok(_accountRepositoryReadOnly.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountCommand createAccountCommand)
            => await SendCommand(createAccountCommand);

        [HttpPost("batch")]
        public async Task<ActionResult> PostFile(IFormFile file)
        {
            if (file == null)
                return BadRequest("The file is required");

            var createAccountBatchCommand = new CreateAccountBatchCommand(file.OpenReadStream());
            return await SendCommand(createAccountBatchCommand);
        }
    }
}
