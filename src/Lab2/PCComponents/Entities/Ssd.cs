using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Ssd : IPermanentMemory
{
    public Ssd(
        int maxSpeed,
        bool isSataConnection,
        double capacityTb,
        double powerConsumption,
        string name)
    {
        MaxSpeed = maxSpeed;
        IsSataConnection = isSataConnection;
        CapacityTb = capacityTb;
        PowerConsumption = powerConsumption;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    public Ssd(
        Ssd baseSsd,
        string name,
        int? maxSpeed = null,
        bool? isSataConnection = null,
        double? capacityTb = null,
        double? powerConsumption = null)
    {
        if (baseSsd is null)
            throw new PcComponentsException("baseSSD must not be null");
        Name = name;
        MaxSpeed = maxSpeed ?? baseSsd.MaxSpeed;
        IsSataConnection = isSataConnection ?? baseSsd.IsSataConnection;
        CapacityTb = capacityTb ?? baseSsd.CapacityTb;
        PowerConsumption = powerConsumption ?? baseSsd.PowerConsumption;
        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Range(1, 1500)]
    public int MaxSpeed { get; private set; }

    public bool IsSataConnection { get; private set; }

    [Range(0, 20)]
    public double CapacityTb { get; private set; }

    public double PowerConsumption { get; private set; }
    public IPermanentMemory Clone()
    {
        return new Ssd(MaxSpeed, IsSataConnection, CapacityTb, PowerConsumption, Name);
    }
}