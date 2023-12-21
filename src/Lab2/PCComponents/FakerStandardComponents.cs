using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

public static class FakerStandardComponents
{
    public static void InitializeInstanceWithStandardComponents(Repository repository)
    {
        if (repository is null)
            throw new PcComponentsException("repository must not be null");
        repository.XmpProfileCatalog.Add("4333MHz", new XmpProfile(
            "16-18-19-22",
            1.35,
            4333,
            "4333MHz"));

        XmpProfile[] kingstonXmpProfiles = { repository.XmpProfileCatalog["4333MHz"] };
        RamFrequency[] kingstonJDEC = { new RamFrequency(3600, 1.35) };
        repository.RamCatalog.Add("Kingston FURY beast", new Ram(
            32,
            kingstonJDEC,
            kingstonXmpProfiles,
            DDRGeneration.FourthGeneration,
            2,
            "DIMM",
            "Kingston FURY beast"));

        repository.SsdCatalog.Add("Samsung 870 EVO", new Ssd(
            560,
            true,
            0.5,
            4,
            "Samsung 870 EVO"));

        repository.PowerSupplyCatalog.Add("AeroCool ECO 400W", new PowerSupply(
            400,
            "AeroCool ECO 400W"));
        repository.PowerSupplyCatalog.Add("GIGABYTE UD1000GM", new PowerSupply(
            1000,
            "GIGABYTE UD1000GM"));

        string[] formFactorLianLi205 = { "Standard-ATX" };
        repository.PcCaseCatalog.Add("LIAN LI LANCOOL 205", new PcCase(
            new Sizes(350, 350),
            new Sizes(350, 350),
            formFactorLianLi205,
            "LIAN LI LANCOOL 205"));

        string[] formFactorLianLi211 = { "Mini-ATX" };
        repository.PcCaseCatalog.Add("LIAN LI LANCOOL 211", new PcCase(
            new Sizes(350, 350),
            new Sizes(350, 350),
            formFactorLianLi211,
            "LIAN LI LANCOOL 205"));

        repository.GpuCatalog.Add("GIGABYTE GeForce RTX 4090 AERO OC", new Gpu(
            new Sizes(342, 150),
            24,
            4,
            2235,
            500,
            "GIGABYTE GeForce RTX 4090 AERO OC"));

        string[] supportedCPUs = { "Intel Core i9-12900KS" };
        repository.BiosCatalog.Add("Intel BIOS 1.0", new Bios(
            "Intel",
            "1.0",
            supportedCPUs,
            "Intel BIOS 1.0"));

        repository.MotherboardCatalog.Add("MSI PRO B760M-A WIFI", new Motherboard(
            repository.BiosCatalog["Intel BIOS 1.0"],
            new Chipset(5600, true),
            "LGA 1700",
            "Standard-ATX",
            2,
            6,
            10,
            DDRGeneration.FourthGeneration,
            "MSI PRO B760M-A WIFI"));

        repository.CpuCatalog.Add("Intel Core i9-12900KS", new Cpu(
            "LGA 1700",
            3.4,
            16,
            241,
            4800,
            false,
            "Intel Core i9-12900KS"));

        string[] supportedSockets = { "LGA 1700" };
        repository.CpuCoolingSystemCatalog.Add("DEEPCOOL Alta 9", new CpuCoolingSystem(
            new Sizes(92, 92),
            supportedSockets,
            65,
            "DEEPCOOL Alta 9"));
        repository.CpuCoolingSystemCatalog.Add("Cooler Master MasterAir MA612", new CpuCoolingSystem(
            new Sizes(120, 120),
            supportedSockets,
            250,
            "Cooler Master MasterAir MA612"));
    }
}