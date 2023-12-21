using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;

public class AddresseeGroup : IAddressee
{
    private List<IAddressee> _group;

    public AddresseeGroup()
    {
        _group = new List<IAddressee>();
    }

    public void AddAddresseeToGroup(IAddressee addressee)
    {
        _group.Add(addressee);
    }

    public void Receive(IMessage message)
    {
        if (message is null)
            throw new MessagesException.MessagesException("Message must not be null");

        foreach (IAddressee addressee in _group)
        {
            addressee.Receive(message);
        }
    }
}