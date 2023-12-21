namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;

public abstract class BaseLocalFileSystemCommand : ICommand
{
    public abstract CommandResult Execute();
}