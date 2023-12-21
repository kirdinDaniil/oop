namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector;

public interface IDeflectorModification
{
    public double Durability { get; }

    public bool IsDestroyed { get; }

    public double GetDamage(double damage);
}