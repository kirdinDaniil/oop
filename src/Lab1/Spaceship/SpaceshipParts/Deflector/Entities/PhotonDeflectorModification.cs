using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector.Entities;

public class PhotonDeflectorModification : IDeflectorModification
{
    public PhotonDeflectorModification()
    {
        Durability = SpaceshipConstants.PhotonDeflectorHealth;
    }

    public double Durability { get; private set; }

    public bool IsDestroyed { get; private set;  }

    public double GetDamage(double damage)
    {
        Durability -= damage;
        if (Durability <= 0)
        {
            IsDestroyed = true;
            return Durability;
        }

        return 0;
    }
}