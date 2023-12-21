using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Invoker;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service.States;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.ServiceException;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service;

public class Service : IService
{
    private IServiceState _state;
    private CommandParser _parser;
    private Invoker _invoker;
    private ICommand? _currentCommand;

    public Service()
    {
        _state = new LfsState(this);
        _invoker = new Invoker();
        _parser = new CommandParser();
    }

    public CommandResult? CommandResult { get; private set; }

    public CommandResult RunCommand()
    {
        if (_currentCommand is null)
            throw new ServiceLayerException("Unknown command or command does not exist");
        _invoker.AddCommand(_currentCommand);
        return _invoker.ExecuteCommands();
    }

    public void ReceiveCommand(string command)
    {
        BaseCommandData parsedCommandData = _parser.ParseCommand(command);
        _currentCommand = parsedCommandData switch
        {
            ConnectData data => _state.GetConnectOperation(data),
            DisconnectData data => _state.GetDisconnectOperation(data),
            TreeGotoData data => _state.GetTreeGotoOperation(data),
            TreeListData data => _state.GetTreeListOperation(data),
            FileCopyData data => _state.GetFileCopyOperation(data),
            FileDeleteData data => _state.GetFileDeleteOperation(data),
            FileMoveData data => _state.GetFileMoveOperation(data),
            FileRenameData data => _state.GetFileRenameOperation(data),
            FileShowData data => _state.GetFileShowOperation(data),
            _ => null,
        };
    }
}