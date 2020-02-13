using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.WebApi.CsvMaps;
using MoneyAdmin.Application.ViewModels;
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
        public ActionResult<IEnumerable<Account>> Get()
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
    

        [HttpPost("uploadcsv")]
        public ActionResult PostFile(IFormFile file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest("File required");
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<AccountCsvMap>();
                    var accounts = csv.GetRecords<Account>();

                    foreach (var account in accounts)
                    {
                        _accountRepository.Add(account);
                    }
                    _accountRepository.Save();
                }

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
