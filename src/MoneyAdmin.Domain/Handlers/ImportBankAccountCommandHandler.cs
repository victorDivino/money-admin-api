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
    public class ImportBankAccountCommandHandler : IRequestHandler<ImportBankAccountCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImportBankAccountCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<CommandResult> Handle(ImportBankAccountCommand request, CancellationToken cancellationToken)
            => Create(request).AsTask;

        private CommandResult Create(ImportBankAccountCommand command)
        {
            try
            {
                if (!command.IsValid)
                    return new Exception("Invalid command");

                using (var reader = new StreamReader(command.File))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<BankAccountCsvMap>();
                    var accounts = csv.GetRecords<BankAccount>();

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
