using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath.Entities;

public class RelativeFilePath : BaseFilePath
{
    private BaseFilePath _previousPath;

    public RelativeFilePath(string path, BaseFilePath previousPath)
        : base(path)
    {
        _previousPath = previousPath;
    }

    public override string GetFullFilePath()
    {
        return _previousPath.GetFullFilePath(Path);
    }

    public override BaseFilePath Clone()
    {
        return new RelativeFilePath((string)Path.Clone(), _previousPath.Clone());
    }

    public override string GetFullFilePath(string nextDirectory)
    {
        var fullPath = new StringBuilder();
        fullPath.Append(Path);
        fullPath.Append('\\');
        fullPath.Append(nextDirectory);
        return _previousPath.GetFullFilePath(fullPath.ToString());
    }
}