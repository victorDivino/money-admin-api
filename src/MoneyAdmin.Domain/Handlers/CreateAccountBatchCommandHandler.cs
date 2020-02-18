using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.CsvMaps;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Domain.Handlers
{
    class CreateAccountBatchCommandHandler : IRequestHandler<CreateAccountBatchCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateAccountBatchCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public Task<CommandResult> Handle(CreateAccountBatchCommand request, CancellationToken cancellationToken) => Create(request).AsTask;

        private CommandResult Create(CreateAccountBatchCommand command)
        {
            try
            {
                if (!command.IsValid)
                    throw new Exception("The file must not be null");

                using (var reader = new StreamReader(command.File))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<AccountCsvMap>();
                    var accounts = csv.GetRecords<Account>();

                    _accountRepository.AddRange(accounts);
                    _accountRepository.Save();
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
