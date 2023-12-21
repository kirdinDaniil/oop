using System.ComponentModel.DataAnnotations;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Gpu
{
    public Gpu(
        Sizes size,
        double vram,
        int pcieVersion,
        int frequency,
        double powerConsumption,
        string name)
    {
        Size = size;
        Vram = vram;
        PcIeVersion = pcieVersion;
        Frequency = frequency;
        PowerConsumption = powerConsumption;
        Name = name;

        ComponentValidator.ValidateObject(size);

        ComponentValidator.ValidateObject(this);
    }

    public Gpu(
        Gpu baseGpu,
        string name,
        Sizes? size = null,
        double? vram = null,
        int? pcieVersion = null,
        int? frequency = null,
        double? powerConsumption = null)
    {
        if (baseGpu is null)
            throw new PcComponentsException("baseGpu must not be null");
        Name = name;
        Size = size ?? baseGpu.Size;
        Vram = vram ?? baseGpu.Vram;
        PcIeVersion = pcieVersion ?? baseGpu.PcIeVersion;
        Frequency = frequency ?? baseGpu.Frequency;
        PowerConsumption = powerConsumption ?? baseGpu.PowerConsumption;

        ComponentValidator.ValidateObject(Size);

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    public Sizes Size { get; private set; }

    [Range(0, 50)]
    public double Vram { get; private set; }

    [Range(1, 6)]
    public int PcIeVersion { get; private set; }

    [Range(1, 5000)]
    public int Frequency { get; private set; }

    [Range(1, 1500)]
    public double PowerConsumption { get; private set; }

    public Gpu Clone()
    {
        return new Gpu(Size, Vram, PcIeVersion, Frequency, PowerConsumption, Name);
    }
}