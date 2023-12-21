using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsFileCopy : BaseLocalFileSystemCommand
{
    private BaseFilePath _sourceFilePath;
    private BaseFilePath _destinationFilePath;

    public LfsFileCopy(BaseFilePath sourceFilePath, BaseFilePath destinationFilePath)
    {
        _sourceFilePath = sourceFilePath;
        _destinationFilePath = destinationFilePath;
    }

    public override CommandResult Execute()
    {
        var file = new FileInfo(_sourceFilePath.GetFullFilePath());

        if (!File.Exists(_sourceFilePath.GetFullFilePath()))
            throw new BllException.BllException("File do not exist");
        if (!Directory.Exists(_destinationFilePath.GetFullFilePath()))
            throw new BllException.BllException("Directory do not exist");
        if (File.Exists(_destinationFilePath.GetFullFilePath() + "\\" + file.Name))
            throw new BllException.BllException("File already exist");

        File.Copy(
            _sourceFilePath.GetFullFilePath(),
            _destinationFilePath.GetFullFilePath() + "\\" + file.Name);

        return new CommandResult(false, string.Empty);
    }
}