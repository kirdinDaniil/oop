using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Engine.Entity.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Hull.Entities;

public class HullThirdClass : IHull
{
    public HullThirdClass()
    {
        Durability = SpaceshipConstants.HullThirdClassHealth;
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