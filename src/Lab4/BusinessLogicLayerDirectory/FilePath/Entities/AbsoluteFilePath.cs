using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath.Entities;

public class AbsoluteFilePath : BaseFilePath
{
    public AbsoluteFilePath(string path)
        : base(path)
    {
    }

    public override string GetFullFilePath()
    {
        return Path;
    }

    public override BaseFilePath Clone()
    {
        return new AbsoluteFilePath((string)Path.Clone());
    }

    public override string GetFullFilePath(string nextDirectory)
    {
        var fullPath = new StringBuilder();
        fullPath.Append(Path);
        fullPath.Append('\\');
        fullPath.Append(nextDirectory);
        return fullPath.ToString();
    }
}