using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle.Entities;

public class SpaceWhale : IObstacle
{
    public SpaceWhale(int population)
    {
        Population = population;
    }

    public int Population { get; init; }
    public double Damage()
        => SpaceConstants.DamageBySpaceWhale;
}