using MediatR;

namespace MoneyAdmin.Domain.Core.Commands
{
    public class CommandBase : IRequest<CommandResult>
    {
    }
}
