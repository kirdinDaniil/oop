namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector;

public interface IDeflector : IDeflectorModification
{
    IDeflectorModification? Modification { get; }
}