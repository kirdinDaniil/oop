using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsFileRename : BaseLocalFileSystemCommand
{
    private BaseFilePath _filePath;
    private string _newFileName;

    public LfsFileRename(BaseFilePath filePath, string newFileName)
    {
        _filePath = filePath;
        _newFileName = newFileName;
    }

    public override CommandResult Execute()
    {
        if (!File.Exists(_filePath.GetFullFilePath()))
            throw new BllException.BllException("File do not exist");

        var file = new FileInfo(_filePath.GetFullFilePath());
        string extension = file.Extension;

        File.Move(file.FullName, _newFileName + extension);

        return new CommandResult(false, string.Empty);
    }
}