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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CommandResult> Handle(CreateAccountCommand command, CancellationToken cancellationToken) => Create(command).AsTask;

        private CommandResult Create(CreateAccountCommand command)
        {
            try
            {
                if (!command.IsValid)
                    return new Exception("Name Invalid");

                var account = _mapper.Map<BankAccount>(command);

                _unitOfWork.AccountRepository.Add(account);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
