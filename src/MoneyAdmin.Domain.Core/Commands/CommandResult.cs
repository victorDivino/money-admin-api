using System;
using System.Threading.Tasks;

namespace MoneyAdmin.Domain.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(Exception exception) => Exception = exception;

        public CommandResult() { }

        public Exception Exception { get; }

        public Task<CommandResult> AsTask => Task.FromResult(this);

        public bool IsSuccess => Exception == null;

        public static CommandResult Success() => new CommandResult();

        public static implicit operator bool(CommandResult result) => result.IsSuccess;

        public static implicit operator CommandResult(Exception exception) => new CommandResult(exception);
    }
}
