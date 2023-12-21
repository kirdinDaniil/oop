using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Records;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Records;

public record PathSimulationResult()
{
    public ImpactResult? ImpactResult { get; init; }
    public PathSegmentResult? AccumulatedPathSegmentResult { get; init; }
}