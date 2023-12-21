using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class XmpProfile
{
    public XmpProfile(
        string timings,
        double voltage,
        int frequency,
        string name)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    public XmpProfile(
        XmpProfile baseXmp,
        string name,
        string? timings = null,
        double? voltage = null,
        int? frequency = null)
    {
        if (baseXmp is null)
            throw new PcComponentsException("baseXMP must not be null");
        Name = name;
        Timings = timings ?? baseXmp.Timings;
        Voltage = voltage ?? baseXmp.Voltage;
        Frequency = frequency ?? baseXmp.Frequency;
        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Required(AllowEmptyStrings = false)]
    [RegularExpression(@"[0-9]+-[0-9]+-[0-9]+-[0-9]+")]
    public string Timings { get; private set; }

    [Range(0, 10)]
    public double Voltage { get; private set; }

    [Range(500, 10000)]
    public int Frequency { get; private set; }

    public XmpProfile Clone()
    {
        return new XmpProfile(Timings, Voltage, Frequency, Name);
    }
}