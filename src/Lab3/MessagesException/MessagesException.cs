using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessagesException;

public class MessagesException : Exception
{
    public MessagesException(string message)
        : base(message)
    {
    }

    public MessagesException()
    {
    }

    public MessagesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}