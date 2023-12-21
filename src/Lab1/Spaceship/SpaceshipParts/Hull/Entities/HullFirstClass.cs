using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entity.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull.Entities;

public class HullFirstClass : IHull
{
    public HullFirstClass()
    {
        Durability = SpaceshipConstants.HullFirstClassHealth;
    }

    public double Durability { get; private set; }

    public bool IsDestroyed { get; private set; }

    public void GetDamage(double damage)
    {
        Durability -= damage;
        if (Durability < 0)
        {
            IsDestroyed = true;
        }
    }
}