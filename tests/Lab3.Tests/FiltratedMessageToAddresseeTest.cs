using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FiltratedMessageToAddresseeTest
{
    [Fact]
    public void SimulateMessageSystem()
    {
        // Arrange
        var user = new User.Entities.User();
        var addressee = new AddresseeUser(user);
        var addresseeFilter = new FakeAddresseeFilter(addressee, ImportanceLevels.Irrelevant);
        var topic = new Topic.Entities.Topic("User Topic", addresseeFilter);
        IMessage massage = Message.Entities.Message.Builder
            .WithHeader("aboba")
            .WithBody("aboba")
            .WithImportance(ImportanceLevels.TopSecret)
            .Build();

        // Act
        topic.Receive(massage);

        // Assert
        Assert.True(addresseeFilter.IsMessageFiltrated);
    }
}