using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic.Entities;

public class Topic : ITopic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public string Name { get; private set; }
    public IAddressee Addressee { get; private set; }
    public ITopic Receive(IMessage message)
    {
        Addressee.Receive(message);
        return this;
    }
}