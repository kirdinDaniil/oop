namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entity.Hull;

public interface IHull
{
    public double Durability { get; }

    public bool IsDestroyed { get; }

    public void GetDamage(double damage);
}