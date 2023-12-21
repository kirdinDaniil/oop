namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Builder;

public interface IBodyBuilder
{
    IImportanceBuilder WithBody(string body);
}