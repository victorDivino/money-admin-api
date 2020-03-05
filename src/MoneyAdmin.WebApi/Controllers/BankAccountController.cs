using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : CustomController
    {
        private readonly IBankAccountRepositoryReadOnly _bankAccountRepositoryReadOnly;

        public BankAccountController(IMediator mediator, IBankAccountRepositoryReadOnly bankAccountRepositoryReadOnly)
            : base(mediator)
            => _bankAccountRepositoryReadOnly = bankAccountRepositoryReadOnly;

        public ActionResult<IEnumerable<BankAccount>> Get()
            => Ok(_bankAccountRepositoryReadOnly.GetAll());

        [HttpPost]
        public async Task<ActionResult> Create(CreateBankAccountCommand createAccountCommand)
            => await SendCommand(createAccountCommand);

        [HttpPost("import")]
        public async Task<ActionResult> Import(IFormFile file)
        {
            if (file == null)
                return BadRequest("The file is required");

            var createAccountBatchCommand = new ImportBankAccountCommand(file.OpenReadStream());
            return await SendCommand(createAccountBatchCommand);
        }
    }
}
