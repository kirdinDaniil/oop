using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class FakeAddresseeLogger : IAddressee
{
    private IAddressee _addressee;

    public FakeAddresseeLogger(IAddressee addressee)
    {
        _addressee = addressee;
        LoggedData = string.Empty;
    }

    public string LoggedData { get; private set; }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");
        Logging(message);
        _addressee.Receive(message);
    }

    private void Logging(IMessage message)
    {
        LoggedData = $"Logger: received message with " +
                     $"Header: {message.Header}\t " +
                     $"Body: {message.Body}\t " +
                     $"to Addressee: {_addressee.GetType().Name}";
        Crayon.Output.Black(LoggedData);
    }
}