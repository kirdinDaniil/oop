using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public interface ISpaceship
{
    public bool HaveAntiNitrineEmitter { get; }

    public bool IsCrewDead { get; }
    public IEngine Engine { get; }
    public IJumpEngine? JumpEngine { get; }

    public ImpactResult GetDamageBy(IObstacle obstacle);
    public void GetDamageModification(double damage);
    public void GetDamageMain(double damage);
    public PathSegmentResult GetPathResults(IEnvironment pathSegment);
}