namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Records;

public record PathSegmentResult()
{
    public double? FuelCost { get; init; }
    public double? Time { get; init; }
}