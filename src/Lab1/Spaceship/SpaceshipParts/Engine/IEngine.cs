namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine;

public interface IEngine
{
    public double GetFuelByPath(double pathLenght);
    public double GetTimeByPath(double pathLenght);
}