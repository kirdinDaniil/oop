using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class SpaceshipException : Exception
{
    public SpaceshipException(string message)
        : base(message)
    {
    }

    public SpaceshipException()
    {
    }

    public SpaceshipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}