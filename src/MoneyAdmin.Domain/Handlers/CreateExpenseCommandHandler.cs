using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Domain.Handlers
{
    public sealed class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, CommandResult>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IExpenseRepository _expenseRepository;

        public CreateExpenseCommandHandler(IAccountRepository accountRepository, IExpenseRepository expenseRepository)
        {
            _accountRepository = accountRepository;
            _expenseRepository = expenseRepository;
        }

        public Task<CommandResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
            => CreateExpense(request).AsTask;

        public CommandResult CreateExpense(CreateExpenseCommand request)
        {
            try
            {
                var bankAcount = _accountRepository.GetById(request.BankAccountId);

                if (bankAcount is null)
                    return new Exception("Bank account not found!");

                var payment = new ExpensePayment(request.Value, request.DueDate, request.PayDay);

                var expense = new Expense(request.BankAccountId,
                    request.Name,
                    request.Value,
                    request.Detail,
                    request.DueDate,
                    request.AccountKind,
                    payment);

                _expenseRepository.Add(expense);

                bankAcount.AddDebit(payment);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
