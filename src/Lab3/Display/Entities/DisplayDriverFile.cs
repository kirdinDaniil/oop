using System.Drawing;
using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.Entities;

public class DisplayDriverFile : IDisplayDriver
{
    private readonly string _filePath = "display.txt";
    public IDisplayDriver Clear()
    {
        using var driverStream = new FileStream(_filePath, FileMode.Open);
        driverStream.SetLength(0);
        driverStream.Close();
        return this;
    }

    public IDisplayDriver WithColor(Color color)
    {
        return this;
    }

    public IDisplayDriver Write(string message)
    {
        using var driverStream = new FileStream(_filePath, FileMode.Open);
        driverStream.Write(Encoding.UTF8.GetBytes(message));
        driverStream.Close();
        return this;
    }
}