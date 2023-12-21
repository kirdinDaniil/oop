using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entity.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public class Avgur : ISpaceship
{
    private IHull _hull;

    private IDeflector? _deflector;

    public Avgur(bool haveDeflectorModification)
    {
        _deflector = new DeflectorThirdClass(haveDeflectorModification ? new PhotonDeflectorModification() : null);
        _hull = new HullThirdClass();
        Engine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineAlpha();
        HaveAntiNitrineEmitter = false;
        IsCrewDead = false;
    }

    public bool HaveAntiNitrineEmitter { get; private set; }
    public bool IsCrewDead { get; private set; }
    public IEngine Engine { get; private set; }
    public IJumpEngine? JumpEngine { get; private set; }

    public ImpactResult GetDamageBy(IObstacle obstacle)
    {
        if (obstacle is null)
            throw new SpaceshipException($"Invalid obstacle: {null} for damage spaceship: {this.GetType().Name} ");

        if (obstacle is AntimatterFlares)
            GetDamageModification(obstacle.Damage());
        else
            GetDamageMain(obstacle.Damage());

        return new ImpactResult()
        {
            IsCrewDead = this.IsCrewDead,
            IsHullDestroyed = _hull.IsDestroyed,
            IsDeflectorDestroyed = _deflector?.IsDestroyed ?? true,
            IsSpaceShipLost = false,
        };
    }

    public void GetDamageModification(double damage)
    {
        if (_deflector?.Modification is not null && !_deflector.Modification.IsDestroyed)
            _deflector.GetDamage(damage);
        else
            IsCrewDead = true;
    }

    public void GetDamageMain(double damage)
    {
        if (_deflector is not null && !_deflector.IsDestroyed)
        {
            double residualDamage = _deflector.GetDamage(damage);
            _hull.GetDamage(Math.Abs(residualDamage));
        }
        else if (!_hull.IsDestroyed)
        {
            _hull.GetDamage(damage);
        }
    }

    public PathSegmentResult GetPathResults(IEnvironment pathSegment)
    {
        if (pathSegment is null)
            throw new SpaceshipException($"Invalid pathSegment: {null} for damage spaceship: {this.GetType().Name} ");

        if (pathSegment is HighDensitySpaceNebulae)
        {
            return new PathSegmentResult()
            {
                FuelCost = JumpEngine?.GetFuelByPath((double)pathSegment.PathLenght),
                Time = SpaceshipConstants.TimeForJump,
            };
        }

        return new PathSegmentResult()
        {
            FuelCost = Engine.GetFuelByPath((double)pathSegment.PathLenght),
            Time = Engine.GetTimeByPath((double)pathSegment.PathLenght),
        };
    }
}