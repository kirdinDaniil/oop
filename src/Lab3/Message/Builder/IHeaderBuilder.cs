namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Builder;

public interface IHeaderBuilder
{
    IBodyBuilder WithHeader(string header);
}