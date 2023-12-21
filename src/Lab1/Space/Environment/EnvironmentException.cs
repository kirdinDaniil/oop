namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;

public class EnvironmentException : System.Exception
{
    public EnvironmentException(string message)
        : base(message)
    {
    }

    public EnvironmentException()
    {
    }

    public EnvironmentException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}