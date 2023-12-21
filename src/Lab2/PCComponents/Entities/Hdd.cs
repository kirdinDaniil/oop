using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Hdd : IPermanentMemory
{
    public Hdd(
        double capacityTb,
        double powerConsumption,
        int spindleSpeed,
        string name)
    {
        CapacityTb = capacityTb;
        PowerConsumption = powerConsumption;
        SpindleSpeed = spindleSpeed;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    public Hdd(
        Hdd baseHdd,
        string name,
        double? capacityTb = null,
        double? powerConsumption = null,
        int? spindleSpeed = null)
    {
        if (baseHdd is null)
            throw new PcComponentsException("baseHDD must not be null");
        Name = name;
        CapacityTb = capacityTb ?? baseHdd.CapacityTb;
        PowerConsumption = powerConsumption ?? baseHdd.PowerConsumption;
        SpindleSpeed = spindleSpeed ?? baseHdd.SpindleSpeed;
        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Range(0, 20)]
    public double CapacityTb { get; private set; }

    public double PowerConsumption { get; private set; }

    [Range(1000, 15000)]
    public int SpindleSpeed { get; private set; }

    public IPermanentMemory Clone()
    {
        return new Hdd(CapacityTb, PowerConsumption, SpindleSpeed, Name);
    }
}