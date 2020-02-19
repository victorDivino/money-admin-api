using MediatR;

namespace MoneyAdmin.Domain.Core.Commands
{
    public abstract class CommandBase : IRequest<CommandResult>
    {
        public abstract bool IsValid { get; }
    }
}
