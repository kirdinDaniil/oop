using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageToUserTest
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

        // Assert
        Assert.Contains(user.Messages, massageStatus => massageStatus.Message.Equals(massage) && !massageStatus.IsRead);
    }
}