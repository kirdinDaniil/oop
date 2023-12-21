using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsFileShow : BaseLocalFileSystemCommand
{
    private BaseFilePath _filePath;

    public LfsFileShow(BaseFilePath filePath)
    {
        _filePath = filePath;
    }

    public override CommandResult Execute()
    {
        var file = new FileInfo(_filePath.GetFullFilePath());
        var resultBuilder = new StringBuilder();
        if (!file.Exists)
            throw new BllException.BllException("File do not exist");

        if (file.Extension != ".txt")
            throw new BllException.BllException("The program does not support opening this file extension");

        var fileStream = new StreamReader(_filePath.GetFullFilePath());

        resultBuilder.Append(fileStream.ReadToEnd());

        fileStream.Close();

        return new CommandResult(false, resultBuilder.ToString());
    }
}