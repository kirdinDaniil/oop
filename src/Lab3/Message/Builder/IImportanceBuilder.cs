using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Builder;

public interface IImportanceBuilder
{
    IMessageBuilder WithImportance(ImportanceLevels importance);
}