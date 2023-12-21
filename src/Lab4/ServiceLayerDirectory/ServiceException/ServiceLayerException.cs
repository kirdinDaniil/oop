using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.ServiceException;

public class ServiceLayerException : Exception
{
    public ServiceLayerException(string message)
        : base(message)
    {
    }

    public ServiceLayerException()
    {
    }

    public ServiceLayerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}