using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Ram
{
    public Ram(
        int capacity,
        IEnumerable<RamFrequency> frequencies,
        IEnumerable<XmpProfile> supportedXmp,
        DDRGeneration ddr,
        double powerConsumption,
        string formFactor,
        string name)
    {
        Capacity = capacity;
        Frequencies = frequencies.ToList();
        SupportedXmp = supportedXmp.ToList();
        Ddr = ddr;
        PowerConsumption = powerConsumption;
        FormFactor = formFactor;
        Name = name;

        foreach (RamFrequency frequency in Frequencies)
        {
            ComponentValidator.ValidateObject(frequency);
        }

        ComponentValidator.ValidateObject(this);
    }

    public Ram(
        Ram baseRam,
        string name,
        int? capacity = null,
        IEnumerable<RamFrequency>? frequencies = null,
        IEnumerable<XmpProfile>? supportedXmp = null,
        DDRGeneration? ddr = null,
        double? powerConsumption = null,
        string? formFactor = null)
    {
        if (baseRam is null)
            throw new PcComponentsException("baseRam must not be null");
        Name = name;
        Capacity = capacity ?? baseRam.Capacity;
        Frequencies = frequencies ?? baseRam.Frequencies;
        SupportedXmp = supportedXmp ?? baseRam.SupportedXmp;
        Ddr = ddr ?? baseRam.Ddr;
        PowerConsumption = powerConsumption ?? baseRam.PowerConsumption;
        FormFactor = formFactor ?? baseRam.FormFactor;

        foreach (RamFrequency frequency in Frequencies)
        {
            ComponentValidator.ValidateObject(frequency);
        }

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Range(2, 1024)]
    public int Capacity { get; private set; }

    public IEnumerable<RamFrequency> Frequencies { get; private set; }

    public IEnumerable<XmpProfile> SupportedXmp { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string FormFactor { get; private set; }

    [Range(1, 5)]
    public DDRGeneration Ddr { get; private set; }

    [Range(0, 10)]
    public double PowerConsumption { get; private set; }

    public Ram Clone()
    {
        var supportedXmpClone = SupportedXmp.Select(xmpProfile => xmpProfile.Clone()).ToList();

        return new Ram(Capacity, Frequencies, supportedXmpClone, Ddr, PowerConsumption, FormFactor, Name);
    }
}