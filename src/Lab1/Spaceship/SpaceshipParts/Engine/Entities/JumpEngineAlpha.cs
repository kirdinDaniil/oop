using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;

public class JumpEngineAlpha : IJumpEngine
{
    public JumpEngineAlpha()
    {
        MaxJumpLenght = SpaceshipConstants.JumpEngineAlphaMaxJumpLenght;
    }

    public double MaxJumpLenght { get; init; }

    public double GetFuelByPath(double pathLenght)
        => pathLenght * SpaceshipConstants.FuelForJump;
}