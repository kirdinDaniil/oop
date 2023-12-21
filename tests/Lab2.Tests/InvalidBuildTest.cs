using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class InvalidBuildTest
{
    [Fact]
    public void PcBuild()
    {
        // Arrange
        var repository = new Repository();
        FakerStandardComponents.InitializeInstanceWithStandardComponents(repository);
        Ram[] ramForBuild = { repository.RamCatalog["Kingston FURY beast"] };
        var ssds = new List<IPermanentMemory>();

        // Act
        PC.Entities.Pc build = PC.Entities.Pc.Builder
            .WithMotherboard(repository.MotherboardCatalog["MSI PRO B760M-A WIFI"])
            .WithCpu(repository.CpuCatalog["Intel Core i9-12900KS"])
            .WithCpuCooling(repository.CpuCoolingSystemCatalog["Cooler Master MasterAir MA612"])
            .WithRam(ramForBuild)
            .WithPermanentMemory(ssds)
            .WithCase(repository.PcCaseCatalog["LIAN LI LANCOOL 211"])
            .WithPowerSupply(repository.PowerSupplyCatalog["GIGABYTE UD1000GM"])
            .Build();

        // Assert
        Assert.True(!build.BuildRemarks.IsPcValid);
    }
}