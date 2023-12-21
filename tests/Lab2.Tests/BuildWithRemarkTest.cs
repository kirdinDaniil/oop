﻿using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class BuildWithRemarkTest
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
            .WithCpuCooling(repository.CpuCoolingSystemCatalog["Cooler Master MasterAir MA612"])
            .WithRam(ramForBuild)
            .WithPermanentMemory(ssds)
            .GetWithGpu(repository.GpuCatalog["GIGABYTE GeForce RTX 4090 AERO OC"])
            .WithCase(repository.PcCaseCatalog["LIAN LI LANCOOL 205"])
            .WithPowerSupply(repository.PowerSupplyCatalog["AeroCool ECO 400W"])
            .Build();

        // Assert
        Assert.True(build.BuildRemarks.IsPcValid
                    && build.BuildRemarks.Remarks.All(remark => remark == "The power supply has insufficient power"));
    }
}