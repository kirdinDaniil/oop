namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public interface IMessenger
{
    public void Receive(string message);

    public void ShowMessage();
}