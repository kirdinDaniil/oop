using Itmo.ObjectOrientedProgramming.Lab2.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class BuildWithoutWarrantyTest
{
    [Fact]
    public void PcBuild()
    {
        // Arrange
        var repository = new Repository();
        FakerStandardComponents.InitializeInstanceWithStandardComponents(repository);
        Ram[] ramForBuild = { repository.RamCatalog["Kingston FURY beast"] };
        IPermanentMemory[] ssds = { repository.SsdCatalog["Samsung 870 EVO"] };

        // Act
        PC.Entities.Pc build = PC.Entities.Pc.Builder
            .WithMotherboard(repository.MotherboardCatalog["MSI PRO B760M-A WIFI"])
            .WithCpu(repository.CpuCatalog["Intel Core i9-12900KS"])
            .WithCpuCooling(repository.CpuCoolingSystemCatalog["DEEPCOOL Alta 9"])
            .WithRam(ramForBuild)
            .WithPermanentMemory(ssds)
            .GetWithGpu(repository.GpuCatalog["GIGABYTE GeForce RTX 4090 AERO OC"])
            .WithCase(repository.PcCaseCatalog["LIAN LI LANCOOL 205"])
            .WithPowerSupply(repository.PowerSupplyCatalog["GIGABYTE UD1000GM"])
            .Build();

        // Assert
        Assert.True(build.BuildRemarks.IsPcValid && !build.BuildRemarks.IsWarrantyInclude);
    }
}