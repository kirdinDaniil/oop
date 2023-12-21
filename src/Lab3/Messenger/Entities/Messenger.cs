namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger.Entities;

public class Messenger : IMessenger
{
    private string _message;

    public Messenger()
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
}