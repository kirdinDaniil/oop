using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTest
{
    [Fact]
    public void SimulateParser()
    {
        // Arrange
        var parser = new CommandParser();
        BaseCommandData commandData;
        var connectData = new ConnectData(string.Empty, string.Empty);

        // Act
        commandData = parser.ParseCommand("connect C:\\ -m local");
        if (commandData is ConnectData data)
            connectData = data;

        // Assert
        Assert.True(commandData is ConnectData && connectData is { Address: "C:\\", Mode: "local" });
    }
}