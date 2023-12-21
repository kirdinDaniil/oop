using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.User;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Entities;

public class AddresseeUser : IAddressee
{
    private IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void Receive(IMessage message)
    {
        _user.Receive(message);
    }
}