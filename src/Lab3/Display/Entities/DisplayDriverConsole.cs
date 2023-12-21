using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display.Entities;

public class DisplayDriverConsole : IDisplayDriver
{
    private Color _color = Color.Empty;
    public IDisplayDriver Clear()
    {
        Console.Clear();
        return this;
    }

    public IDisplayDriver WithColor(Color color)
    {
        _color = color;
        if (_color == Color.Empty) throw new MessagesException.MessagesException("Color must not be null");
        return this;
    }

    public IDisplayDriver Write(string message)
    {
        Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text($"Display Driver: {message}");
        return this;
    }
}