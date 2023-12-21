using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.BllException;

public class BllException : Exception
{
    public BllException(string message)
        : base(message)
    {
    }

    public BllException()
    {
    }

    public BllException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}