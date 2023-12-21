using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class PowerSupply
{
    public PowerSupply(int power, string name)
    {
        Power = power;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Range(1, 5000)]
    public int Power { get; private set; }

    public PowerSupply Clone()
    {
        return new PowerSupply(Power, Name);
    }
}