namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Records;

public record ImpactResult()
{
    public bool IsHullDestroyed { get; init; }

    public bool IsDeflectorDestroyed { get; init; }
    public bool IsCrewDead { get; init; }

    public bool IsSpaceShipLost { get; init; }
}