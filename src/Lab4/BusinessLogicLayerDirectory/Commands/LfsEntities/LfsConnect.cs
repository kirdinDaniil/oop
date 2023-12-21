using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsConnect : BaseLocalFileSystemCommand
{
    private string _filePath;
    private AbsoluteFilePath? _systemAbsoluteFilePath;
    private BaseFilePath? _systemCurrentFilePath;

    public LfsConnect(string filePath, AbsoluteFilePath? systemAbsoluteFilePath, BaseFilePath? systemCurrentFilePath)
    {
        _filePath = filePath;
        _systemCurrentFilePath = systemCurrentFilePath;
        _systemAbsoluteFilePath = systemAbsoluteFilePath;
    }

    public override CommandResult Execute()
    {
        _systemAbsoluteFilePath = new AbsoluteFilePath(_filePath);
        _systemCurrentFilePath = _systemAbsoluteFilePath.Clone();
        return new CommandResult(false, string.Empty);
    }
}