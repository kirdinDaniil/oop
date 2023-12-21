using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.User.Records;

namespace Itmo.ObjectOrientedProgramming.Lab3.User;

public interface IUser
{
    public IEnumerable<MessageStatus> Messages { get; }

    public void Receive(IMessage message);

    public void ReadMessage(IMessage message);
}