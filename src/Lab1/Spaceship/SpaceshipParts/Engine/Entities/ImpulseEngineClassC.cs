using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;

public class ImpulseEngineClassC : IEngine
{
    public double GetFuelByPath(double pathLenght)
        => (GetTimeByPath(pathLenght)
            * SpaceshipConstants.ImpulseEngineClassCFuelForTick) +
           SpaceshipConstants.ImpulseEngineFuelForStart;

    public double GetTimeByPath(double pathLenght)
        => pathLenght / SpaceshipConstants.ImpulseEngineClassCSpeed;
}