using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public interface ITopic
{
    public string Name { get; }

    public IAddressee Addressee { get; }

    public ITopic Receive(IMessage message);
}