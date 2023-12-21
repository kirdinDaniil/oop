using Itmo.ObjectOrientedProgramming.Lab3.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;

public class AddresseeDisplay : IAddressee
{
    private IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");
        _display.Receive(message.Body);
    }
}