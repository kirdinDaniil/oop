using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

public class Repository
{
    public Repository()
    {
        BiosCatalog = new Dictionary<string, Bios>();
        CpuCatalog = new Dictionary<string, Cpu>();
        CpuCoolingSystemCatalog = new Dictionary<string, CpuCoolingSystem>();
        GpuCatalog = new Dictionary<string, Gpu>();
        HddCatalog = new Dictionary<string, Hdd>();
        MotherboardCatalog = new Dictionary<string, Motherboard>();
        PcCaseCatalog = new Dictionary<string, PcCase>();
        PowerSupplyCatalog = new Dictionary<string, PowerSupply>();
        RamCatalog = new Dictionary<string, Ram>();
        SsdCatalog = new Dictionary<string, Ssd>();
        WiFiAdapterCatalog = new Dictionary<string, WiFiAdapter>();
        XmpProfileCatalog = new Dictionary<string, XmpProfile>();
    }

    public Dictionary<string, Bios> BiosCatalog { get; private set; }
    public Dictionary<string, Cpu> CpuCatalog { get; private set; }
    public Dictionary<string, CpuCoolingSystem> CpuCoolingSystemCatalog { get; private set; }
    public Dictionary<string, Gpu> GpuCatalog { get; private set; }
    public Dictionary<string, Hdd> HddCatalog { get; private set; }
    public Dictionary<string, Motherboard> MotherboardCatalog { get; private set; }
    public Dictionary<string, PcCase> PcCaseCatalog { get; private set; }
    public Dictionary<string, PowerSupply> PowerSupplyCatalog { get; private set; }
    public Dictionary<string, Ram> RamCatalog { get; private set; }
    public Dictionary<string, Ssd> SsdCatalog { get; private set; }
    public Dictionary<string, WiFiAdapter> WiFiAdapterCatalog { get; private set; }
    public Dictionary<string, XmpProfile> XmpProfileCatalog { get; private set; }
}