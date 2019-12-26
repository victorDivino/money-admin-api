using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Application.ViewModels;
using MoneyAdmin.Domain;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRepositoryReadOnly _accountRepositoryReadOnly;

        public AccountController(IAccountRepository accountRepository, IAccountRepositoryReadOnly accountRepositoryReadOnly)
        {
            _accountRepository = accountRepository;
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
        public ActionResult Create(AccountViewModel accountViewModel)
        {
            try
            {
                var account = new Account(accountViewModel.Name, accountViewModel.InitialValue);
                _accountRepository.Add(account);
                _accountRepository.Save();
                return Ok(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
