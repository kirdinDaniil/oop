using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;

public class AddresseeMessenger : IAddressee
{
    private IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");
        _messenger.Receive(message.Body);
    }
}