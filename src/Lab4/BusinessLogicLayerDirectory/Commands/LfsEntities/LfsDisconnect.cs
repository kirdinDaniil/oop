using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsDisconnect : BaseLocalFileSystemCommand
{
    private AbsoluteFilePath? _systemAbsoluteFilePath;
    private BaseFilePath? _systemCurrentFilePath;

    public LfsDisconnect(AbsoluteFilePath? systemAbsoluteFilePath, BaseFilePath? systemCurrentFilePath)
    {
        _systemAbsoluteFilePath = systemAbsoluteFilePath;
        _systemCurrentFilePath = systemCurrentFilePath;
    }

    public override CommandResult Execute()
    {
        _systemAbsoluteFilePath = null;
        _systemCurrentFilePath = null;
        return new CommandResult(true, string.Empty);
    }
}