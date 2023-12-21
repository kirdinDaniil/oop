namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

public interface IPermanentMemory
{
    public double CapacityTb { get; }

    public double PowerConsumption { get; }

    public IPermanentMemory Clone();
}