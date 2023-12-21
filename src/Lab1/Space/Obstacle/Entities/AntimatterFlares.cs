using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle.Entities;

public class AntimatterFlares : IObstacle
{
    public double Damage()
        => SpaceConstants.DamageByAntimatterFlares;
}