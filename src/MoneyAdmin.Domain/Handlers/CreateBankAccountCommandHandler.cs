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
    public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBankAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CommandResult> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
            => Create(request).AsTask;

        private CommandResult Create(CreateBankAccountCommand request)
        {
            try
            {
                if (!request.IsValid)
                    return new Exception("Name Invalid");

                var account = _mapper.Map<BankAccount>(request);

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
