using System;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;

public class JumpEngineOmega : IJumpEngine
{
    public JumpEngineOmega()
    {
        MaxJumpLenght = SpaceshipConstants.JumpEngineOmegaMaxJumpLenght;
    }

    public double MaxJumpLenght { get; init; }
    public double GetFuelByPath(double pathLenght)
        => (pathLenght * Math.Log(pathLenght)) * SpaceshipConstants.FuelForJump;
}