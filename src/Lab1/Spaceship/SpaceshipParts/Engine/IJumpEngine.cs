namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine;

public interface IJumpEngine
{
    public double MaxJumpLenght { get; }
    public double GetFuelByPath(double pathLenght);
}