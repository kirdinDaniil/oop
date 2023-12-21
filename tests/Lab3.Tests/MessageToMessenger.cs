using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageToMessenger
{
    [Fact]
    public void SimulateMessageSystem()
    {
        // Arrange
        var messenger = new FakeMessenger();
        var addressee = new AddresseeMessenger(messenger);
        var topic = new Topic.Entities.Topic("User Topic", addressee);
        IMessage massage = Message.Entities.Message.Builder
            .WithHeader("aboba")
            .WithBody("aboba")
            .WithImportance(ImportanceLevels.Irrelevant)
            .Build();

        // Act
        topic.Receive(massage);

        // Assert
        Assert.True(messenger.FakeShowMessage() == "Messenger: aboba");
    }
}