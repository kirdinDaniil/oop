namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;

public abstract class BaseFilePath : IFilePath
{
    protected BaseFilePath(string path)
    {
        Path = path;
    }

    protected string Path { get;  set; }

    public abstract string GetFullFilePath();
    public abstract BaseFilePath Clone();

    public abstract string GetFullFilePath(string nextDirectory);
}