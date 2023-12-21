using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

public interface IDisplay
{
    public IDisplayDriver DisplayDriver { get; }
    public void Receive(string message);

    public void ShowMessage(Color messageColor);
}