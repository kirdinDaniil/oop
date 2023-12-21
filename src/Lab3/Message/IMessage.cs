using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public interface IMessage
{
    public string Header { get; }

    public string Body { get; }

    public ImportanceLevels Importance { get; }
}