using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsTreeGoto : BaseLocalFileSystemCommand
{
    private BaseFilePath _filePath;
    private BaseFilePath? _systemCurrentFilePath;
    public LfsTreeGoto(BaseFilePath filePath, BaseFilePath? systemCurrentFilePath)
    {
        _filePath = filePath;
        _systemCurrentFilePath = systemCurrentFilePath;
    }

    public override CommandResult Execute()
    {
        _systemCurrentFilePath = _filePath;
        return new CommandResult(false, string.Empty);
    }
}