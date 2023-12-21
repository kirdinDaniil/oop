using System;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;

public class JumpEngineGamma : IJumpEngine
{
    public JumpEngineGamma()
    {
        MaxJumpLenght = SpaceshipConstants.JumpEngineGammaMaxJumpLenght;
    }

    public double MaxJumpLenght { get; init; }
    public double GetFuelByPath(double pathLenght)
        => Math.Pow(pathLenght, 2) * SpaceshipConstants.FuelForJump;
}