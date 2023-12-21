using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Cpu
{
    public Cpu(
        string socket,
        double coreFrequency,
        int coreAmount,
        double tdp,
        int maxRamFrequency,
        bool isGraphicsIntegrated,
        string name)
    {
        Socket = socket;
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Tdp = tdp;
        MaxRamFrequency = maxRamFrequency;
        IsGraphicsIntegrated = isGraphicsIntegrated;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    public Cpu(
        Cpu baseCpu,
        string name,
        string? socket = null,
        double? coreFrequency = null,
        int? coreAmount = null,
        double? tdp = null,
        int? maxRamFrequency = null,
        bool? isGraphicsIntegrated = null)
    {
        if (baseCpu is null)
            throw new PcComponentsException("baseCPU must not be null");
        Name = name;
        Socket = socket ?? baseCpu.Socket;
        CoreFrequency = coreFrequency ?? baseCpu.CoreFrequency;
        CoreAmount = coreAmount ?? baseCpu.CoreAmount;
        Tdp = tdp ?? baseCpu.Tdp;
        MaxRamFrequency = maxRamFrequency ?? baseCpu.MaxRamFrequency;
        IsGraphicsIntegrated = isGraphicsIntegrated ?? baseCpu.IsGraphicsIntegrated;
        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string Socket { get; private set; }

    [Range(0, 50)]
    public double CoreFrequency { get; private set; }

    [Range(1, 600)]
    public double Tdp { get; private set; }

    [Range(1, 128)]
    public int CoreAmount { get; private set; }

    [Range(500, 10000)]
    public int MaxRamFrequency { get; private set; }

    public bool IsGraphicsIntegrated { get; private set; }

    public Cpu Clone()
    {
        return new Cpu(Socket, CoreFrequency, CoreAmount, Tdp, MaxRamFrequency, IsGraphicsIntegrated, Name);
    }
}