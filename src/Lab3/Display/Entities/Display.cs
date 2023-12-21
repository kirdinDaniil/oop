using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.Entities;

public class Display : IDisplay
{
    private string _massage;
    public Display(IDisplayDriver displayDriver)
    {
        DisplayDriver = displayDriver;
        _massage = string.Empty;
    }

    public IDisplayDriver DisplayDriver { get; private set; }

    public void Receive(string message)
    {
        _massage = message;
    }

    public void ShowMessage(Color messageColor)
    {
        DisplayDriver
            .Clear()
            .WithColor(messageColor)
            .Write(_massage);
    }
}