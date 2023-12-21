﻿using Itmo.ObjectOrientedProgramming.Lab1.Сonstants;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.SpaceshipParts.Deflector.Entities;

public class DeflectorSecondClass : IDeflector
{
    public DeflectorSecondClass(IDeflectorModification? deflectorModification)
    {
        Durability = SpaceshipConstants.DeflectorSecondClassHealth;
        Modification = deflectorModification;
    }

    public IDeflectorModification? Modification { get; private set; }
    public double Durability { get; private set; }

    public bool IsDestroyed { get; private set; }

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