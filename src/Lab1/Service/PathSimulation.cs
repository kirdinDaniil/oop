using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class PathSimulation
{
    private readonly ImpactResult _successImpactResult;
    public PathSimulation(ISpaceship spaceship, IEnumerable<IEnvironment> pathSegments)
    {
        _successImpactResult = new ImpactResult();
        Spaceship = spaceship;
        PathSegments = pathSegments;
    }

    public ISpaceship Spaceship { get;  private set; }

    private IEnumerable<IEnvironment> PathSegments { get;  set; }

    public PathSimulationResult StartPathSimulation()
    {
        var impactResult = new ImpactResult();
        double? fuelCostAccumulator = 0;
        double? timeAccumulator = 0;
        foreach (IEnvironment environment in PathSegments)
        {
            impactResult = environment.ImpactOnSpaceship(Spaceship);
            if (impactResult != _successImpactResult)
                break;
            PathSegmentResult intermediatePathSegmentResult = Spaceship.GetPathResults(environment);
            fuelCostAccumulator += (intermediatePathSegmentResult.Time == SpaceshipConstants.TimeForJump) ?
                intermediatePathSegmentResult.FuelCost * ServiceConstants.StandardFuelPrice :
                intermediatePathSegmentResult.FuelCost * ServiceConstants.GravitonMatterFuelPrice;
            timeAccumulator += intermediatePathSegmentResult.Time;
        }

        if (impactResult == _successImpactResult)
        {
            var accumulatedPathSegmentResult = new PathSegmentResult()
            {
                FuelCost = fuelCostAccumulator,
                Time = timeAccumulator,
            };

            return new PathSimulationResult()
            {
                ImpactResult = _successImpactResult,
                AccumulatedPathSegmentResult = accumulatedPathSegmentResult,
            };
        }

        return new PathSimulationResult()
        {
            ImpactResult = impactResult,
            AccumulatedPathSegmentResult = null,
        };
    }
}