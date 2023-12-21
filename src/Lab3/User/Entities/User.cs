using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.User.Records;

namespace Itmo.ObjectOrientedProgramming.Lab3.User.Entities;

public class User : IUser
{
    public User()
    {
        Messages = new List<MessageStatus>();
    }

    public IEnumerable<MessageStatus> Messages { get; private set; }
    public void Receive(IMessage message)
    {
        Messages = Messages.Append(new MessageStatus(message, false));
    }

    public void ReadMessage(IMessage message)
    {
        foreach (MessageStatus receivedMessage in Messages)
        {
            if (!receivedMessage.Message.Equals(message)) continue;
            if (receivedMessage.IsRead)
                throw new MessagesException.MessagesException("Message already has a read status");

            IMessage temporaryMessage = receivedMessage.Message;

            Messages = Messages.Where(deletedMessage => deletedMessage != receivedMessage);

            Messages = Messages.Append(new MessageStatus(temporaryMessage, true));
        }
    }
}