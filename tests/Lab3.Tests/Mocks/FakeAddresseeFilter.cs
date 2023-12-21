using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class FakeAddresseeFilter : IAddressee
{
    private IAddressee _addressee;

    private ImportanceLevels _importance;

    public FakeAddresseeFilter(IAddressee addressee, ImportanceLevels addresseeImportance)
    {
        _addressee = addressee;
        _importance = addresseeImportance;
        IsMessageFiltrated = false;
    }

    public bool IsMessageFiltrated { get; private set; }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");
        if (message.Importance <= _importance)
            _addressee.Receive(message);
        IsMessageFiltrated = true;
    }
}