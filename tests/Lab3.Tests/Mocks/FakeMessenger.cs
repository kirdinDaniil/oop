using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;

public class FakeMessenger : IMessenger
{
    private string _message;

    public FakeMessenger()
    {
        _message = string.Empty;
    }

    public void Receive(string message)
    {
        _message = message;
    }

    public void ShowMessage()
    {
        Crayon.Output.Underline("Messenger: ");
        Crayon.Output.Black(_message);
    }

    public string FakeShowMessage() => $"Messenger: {_message}";
}