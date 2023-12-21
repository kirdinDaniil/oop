using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageToUserAndMessageAlreadyReadTest
{
    [Fact]
    public void SimulateMessageSystem()
    {
        // Arrange
        var user = new User.Entities.User();
        var addressee = new AddresseeUser(user);
        var topic = new Topic.Entities.Topic("User Topic", addressee);
        IMessage massage = Message.Entities.Message.Builder
            .WithHeader("aboba")
            .WithBody("aboba")
            .WithImportance(ImportanceLevels.Irrelevant)
            .Build();

        // Act
        topic.Receive(massage);
        user.ReadMessage(massage);

        // Assert
        try
        {
            user.ReadMessage(massage);
            Assert.Fail();
        }
        catch (MessagesException.MessagesException e)
        {
            Assert.True(e.Message == "Message already has a read status");
        }
    }
}