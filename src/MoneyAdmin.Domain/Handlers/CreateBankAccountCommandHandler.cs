using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Domain.Handlers
{
    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
            => Create(request).AsTask;

        private CommandResult Create(CreateBankAccountCommand request)
        {
            try
            {
                if (!request.IsValid)
                    return new Exception("Name Invalid");

                var newBankAccount = new BankAccount(request.Name, request.InitialValue);

                _unitOfWork.BankAccountRepository.Add(newBankAccount);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
