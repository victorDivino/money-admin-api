using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyAdmin.Domain.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository) => _accountRepository = accountRepository;

        public Task<CommandResult> Handle(CreateAccountCommand command, CancellationToken cancellationToken) => Create(command).AsTask;

        private CommandResult Create(CreateAccountCommand command)
        {
            try
            {
                var account = new Account(command.Name, command.InitialValue);

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
