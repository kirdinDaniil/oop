using System.ComponentModel.DataAnnotations;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class Motherboard
{
    public Motherboard(
        Bios bios,
        Chipset chipsetType,
        string socket,
        string formFactor,
        int pcieSlots,
        int ramSlots,
        int sataConnectors,
        DDRGeneration supportedDdr,
        string name)
    {
        CurrentBios = bios;
        ChipsetType = chipsetType;
        Socket = socket;
        FormFactor = formFactor;
        PcIeSlots = pcieSlots;
        RamSlots = ramSlots;
        SataConnectors = sataConnectors;
        SupportedDdr = supportedDdr;
        Name = name;
        ComponentValidator.ValidateObject(chipsetType);

        ComponentValidator.ValidateObject(this);
    }

    public Motherboard(
        Motherboard baseMotherboard,
        string name,
        Bios? bios = null,
        Chipset? chipsetType = null,
        string? socket = null,
        string? formFactor = null,
        int? pcieSlots = null,
        int? ramSlots = null,
        int? sataConnectors = null,
        DDRGeneration? supportedDdr = null)
    {
        if (baseMotherboard is null)
            throw new PcComponentsException("baseMotherboard must not be null");
        Name = name;
        CurrentBios = bios ?? baseMotherboard.CurrentBios;
        ChipsetType = chipsetType ?? baseMotherboard.ChipsetType;
        Socket = socket ?? baseMotherboard.Socket;
        FormFactor = formFactor ?? baseMotherboard.FormFactor;
        PcIeSlots = pcieSlots ?? baseMotherboard.PcIeSlots;
        RamSlots = ramSlots ?? baseMotherboard.RamSlots;
        SataConnectors = sataConnectors ?? baseMotherboard.SataConnectors;
        SupportedDdr = supportedDdr ?? baseMotherboard.SupportedDdr;
        ComponentValidator.ValidateObject(ChipsetType);

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    public Bios CurrentBios { get; private set; }

    public Chipset ChipsetType { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string Socket { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string FormFactor { get; private set; }

    [Range(0, 50)]
    public int PcIeSlots { get; private set; }

    [Range(1, 50)]
    public int SataConnectors { get; private set; }

    [Range(1, 50)]
    public int RamSlots { get; private set; }

    [Range(1, 5)]
    public DDRGeneration SupportedDdr { get; private set; }

    public Motherboard Clone()
    {
        return new Motherboard((Bios)CurrentBios.Clone(), ChipsetType, Socket, FormFactor, PcIeSlots, RamSlots, SataConnectors, SupportedDdr, Name);
    }
}