using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Constants;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;

public class LfsTreeList : BaseLocalFileSystemCommand
{
    private BaseFilePath _filePath;
    private int _depth;
    public LfsTreeList(BaseFilePath filePath, int depth = 1)
    {
        _filePath = filePath;
        _depth = depth;
    }

    public override CommandResult Execute()
    {
        string fullFilePath = _filePath.GetFullFilePath();
        var resultBuilder = new StringBuilder();
        if (!Directory.Exists(fullFilePath))
            throw new BllException.BllException("Directory doesnt exists");

        var directory = new DirectoryInfo(fullFilePath);
        resultBuilder.Append(BllConstants.DirectorySymbol());
        resultBuilder.Append(directory.Name);
        resultBuilder.Append('\n');
        GetDirectoryInfo(resultBuilder, directory, 1);
        return new CommandResult(false, resultBuilder.ToString());
    }

    private static void GetFilesFromDirectory(StringBuilder resultBuilder, DirectoryInfo directory, string tabulation)
    {
        foreach (FileInfo file in directory.GetFiles())
        {
            resultBuilder.Append(tabulation);
            resultBuilder.Append(BllConstants.OffsetSymbol());
            resultBuilder.Append(BllConstants.FileSymbol());
            resultBuilder.Append(file.Name);
            resultBuilder.Append('\n');
        }
    }

    private void GetDirectoryInfo(StringBuilder resultBuilder, DirectoryInfo directory, int currentDepth)
    {
        string tabulation = new string('\t', currentDepth - 1);
        GetFilesFromDirectory(resultBuilder, directory, tabulation);
        foreach (DirectoryInfo curDirectory in directory.GetDirectories())
        {
            resultBuilder.Append(tabulation);
            resultBuilder.Append(BllConstants.OffsetSymbol());
            resultBuilder.Append(BllConstants.DirectorySymbol());
            resultBuilder.Append(curDirectory.Name);
            resultBuilder.Append('\n');
            if (currentDepth < _depth)
                GetDirectoryInfo(resultBuilder, curDirectory, currentDepth + 1);
        }
    }
}