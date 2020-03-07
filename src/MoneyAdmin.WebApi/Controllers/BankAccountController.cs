using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.WebApi.ViewModels;

namespace MoneyAdmin.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : CustomController
    {
        private readonly IBankAccountRepositoryReadOnly _bankAccountRepositoryReadOnly;
        private readonly IMapper _mapper;

        public BankAccountController(IMediator mediator, IBankAccountRepositoryReadOnly bankAccountRepositoryReadOnly, IMapper mapper)
            : base(mediator)
        {
            _bankAccountRepositoryReadOnly = bankAccountRepositoryReadOnly;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public ActionResult<IQueryable<BankAccountViewModel>> GetAll()
            => Ok(_bankAccountRepositoryReadOnly.GetAll().ProjectTo<BankAccountViewModel>(_mapper.ConfigurationProvider));

        [HttpPost("create")]
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
