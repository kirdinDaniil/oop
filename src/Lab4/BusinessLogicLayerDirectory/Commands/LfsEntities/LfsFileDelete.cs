using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsFileDelete : BaseLocalFileSystemCommand
{
    private BaseFilePath _filePath;

    public LfsFileDelete(BaseFilePath filePath)
    {
        _filePath = filePath;
    }

    public override CommandResult Execute()
    {
        if (!File.Exists(_filePath.GetFullFilePath()))
            throw new BllException.BllException("File do not exist");

        File.Delete(_filePath.GetFullFilePath());

        return new CommandResult(false, string.Empty);
    }
}