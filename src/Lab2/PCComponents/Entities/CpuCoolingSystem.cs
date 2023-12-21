using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class CpuCoolingSystem
{
    public CpuCoolingSystem(
        Sizes size,
        IEnumerable<string> supportedSockets,
        double tdp,
        string name)
    {
        Size = size;
        SupportedSockets = supportedSockets.ToList();
        Tdp = tdp;
        Name = name;
        ComponentValidator.ValidateObject(size);

        ComponentValidator.ValidateObject(this);
    }

    public CpuCoolingSystem(
        CpuCoolingSystem baseCpuCoolingSystem,
        string name,
        Sizes? size = null,
        IEnumerable<string>? supportedSockets = null,
        double? tdp = null)
    {
        if (baseCpuCoolingSystem is null)
            throw new PcComponentsException("baseCPUCoolingSystem must not be null");
        Name = name;
        Size = size ?? baseCpuCoolingSystem.Size;
        SupportedSockets = supportedSockets ?? baseCpuCoolingSystem.SupportedSockets;
        Tdp = tdp ?? baseCpuCoolingSystem.Tdp;

        ComponentValidator.ValidateObject(Size);

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    public Sizes Size { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public IEnumerable<string> SupportedSockets { get; private set; }

    [Range(1, 600)]
    public double Tdp { get; private set; }

    public CpuCoolingSystem Clone()
    {
        return new CpuCoolingSystem(Size, SupportedSockets, Tdp, Name);
    }
}