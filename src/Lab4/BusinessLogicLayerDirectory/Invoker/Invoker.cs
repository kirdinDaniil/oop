using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Invoker;

public class Invoker
{
    private List<ICommand> _commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public CommandResult ExecuteCommands()
    {
        var resultBuilder = new StringBuilder();
        bool isDisconnected = false;
        foreach (ICommand command in _commands)
        {
            CommandResult result = command.Execute();
            resultBuilder.Append(result.Result);
            isDisconnected = result.IsDisconnect;
        }

        _commands.Clear();
        return new CommandResult(isDisconnected, resultBuilder.ToString());
    }
}