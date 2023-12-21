using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplayDriver
{
    IDisplayDriver Clear();

    IDisplayDriver WithColor(Color color);

    IDisplayDriver Write(string message);
}