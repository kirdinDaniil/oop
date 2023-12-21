using System;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;

public class ImpulseEngineClassE : IEngine
{
    public double GetFuelByPath(double pathLenght)
        => (GetTimeByPath(pathLenght)
            * SpaceshipConstants.ImpulseEngineClassEFuelForTick) +
           SpaceshipConstants.ImpulseEngineFuelForStart;

    public double GetTimeByPath(double pathLenght)
        => Math.Log(pathLenght + 1);
}