using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeLogger;

public class AddresseeLogger : IAddressee
{
    private IAddressee _addressee;

    public AddresseeLogger(IAddressee addressee)
    {
        _addressee = addressee;
    }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");
        Logging(message);
        _addressee.Receive(message);
    }

    private void Logging(IMessage message)
    {
        Crayon.Output.Black($"Logger: received message with " +
                            $"Header: {message.Header}\t " +
                            $"Body: {message.Body}\t " +
                            $"to Addressee: {_addressee.GetType().Name}");
    }
}