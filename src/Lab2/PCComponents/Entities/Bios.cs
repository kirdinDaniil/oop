using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Bios
{
    public Bios(
        string type,
        string version,
        IEnumerable<string> supportedCpu,
        string name)
    {
        Type = type;
        Version = version;
        Name = name;
        SupportedCpuNames = supportedCpu.ToList();
        ComponentValidator.ValidateObject(this);
    }

    public Bios(
        Bios baseBios,
        string name,
        string? type = null,
        string? version = null,
        IEnumerable<string>? supportedCpu = null)
    {
        if (baseBios is null)
            throw new PcComponentsException("baseBIOS must not be null");
        Name = name;
        Type = type ?? baseBios.Type;
        Version = version ?? baseBios.Version;
        SupportedCpuNames = supportedCpu ?? baseBios.SupportedCpuNames;

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string Type { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string Version { get; private set; }

    public IEnumerable<string> SupportedCpuNames { get; private set; }

    public Bios Clone()
    {
        return new Bios(Type, Version, SupportedCpuNames, Name);
    }
}