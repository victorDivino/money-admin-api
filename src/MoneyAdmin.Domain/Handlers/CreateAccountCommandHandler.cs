using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Domain.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public Task<CommandResult> Handle(CreateAccountCommand command, CancellationToken cancellationToken) => Create(command).AsTask;

        private CommandResult Create(CreateAccountCommand command)
        {
            try
            {
                var account = _mapper.Map<Account>(command);

                _accountRepository.Add(account);
                _accountRepository.Save();

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
