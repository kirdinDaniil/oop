using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;

public class OrdinarySpace : IEnvironment
{
    public OrdinarySpace(EnvironmentLenght lenght)
    {
        PathLenght = lenght;
        Obstacles = new List<IObstacle>();
    }

    public IEnumerable<IObstacle> Obstacles { get; private set; }
    public EnvironmentLenght PathLenght { get; }

    public void AddObstacle(IObstacle obstacle)
    {
        if (obstacle is Asteroid or Meteorite)
            Obstacles = Obstacles.Append(obstacle);
        else
            throw new EnvironmentException($"Invalid obstacle: {obstacle?.GetType().Name} for  environment: {this.GetType().Name}");
    }

    public ImpactResult? ImpactOnSpaceship(ISpaceship spaceship)
    {
        if (spaceship is null)
            throw new EnvironmentException($"Invalid spaceship: {null} for  environment: {this.GetType().Name}");

        var impactResult = new ImpactResult();

        foreach (IObstacle obstacle in Obstacles)
        {
            ImpactResult impactIntermediateResult = spaceship.GetDamageBy(obstacle);
            if (impactIntermediateResult.IsCrewDead || impactIntermediateResult.IsHullDestroyed)
                return impactIntermediateResult;
            impactResult = impactIntermediateResult;
        }

        return impactResult;
    }
}