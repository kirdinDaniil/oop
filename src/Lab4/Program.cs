using Itmo.ObjectOrientedProgramming.Lab4.PresentationLayerDirectory.CommandLineInterface;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var commandLineInterface = new CommandLineInterface();
        commandLineInterface.Start();
    }
}