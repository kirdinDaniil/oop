using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

public class PcComponentsException : Exception
{
    public PcComponentsException(string message)
        : base(message)
    {
    }

    public PcComponentsException()
    {
    }

    public PcComponentsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}