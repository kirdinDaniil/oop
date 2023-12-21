using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;

public interface IEnvironment
{
    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentLenght PathLenght { get; }
    public void AddObstacle(IObstacle obstacle);
    public ImpactResult? ImpactOnSpaceship(ISpaceship spaceship);
}