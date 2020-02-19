using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.CsvMaps;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Domain.Handlers
{
    public class CreateAccountBatchCommandHandler : IRequestHandler<CreateAccountBatchCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountBatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CommandResult> Handle(CreateAccountBatchCommand request, CancellationToken cancellationToken) => Create(request).AsTask;

        private CommandResult Create(CreateAccountBatchCommand command)
        {
            try
            {
                if (!command.IsValid)
                    return new Exception("Invalid command");

                using (var reader = new StreamReader(command.File))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<AccountCsvMap>();
                    var accounts = csv.GetRecords<Account>();

                    if (accounts == null)
                        return new Exception("Cvs file is empty");

                    _unitOfWork.AccountRepository.AddRange(accounts);
                }

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
