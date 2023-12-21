using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Xunit;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShuttleAndAvgurInHighDensitySpaceNebulaeTest
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var shuttle = new Shuttle();
        var avgur = new Avgur(false);

        var highDensitySpaceNebulae = new HighDensitySpaceNebulae(EnvironmentLenght.Normal);
        var environments = new List<IEnvironment>();
        environments.Add(highDensitySpaceNebulae);

        var pathSimulationShuttle = new PathSimulation(shuttle, environments);
        var pathSimulationAvgur = new PathSimulation(avgur, environments);
        var successImpactResult = new ImpactResult();

        // Act
        PathSimulationResult shuttleResult = pathSimulationShuttle.StartPathSimulation();
        PathSimulationResult avgurResult = pathSimulationAvgur.StartPathSimulation();

        // Assert
        Assert.True(shuttleResult.ImpactResult != successImpactResult);
        Assert.True(avgurResult.ImpactResult != successImpactResult);
    }
}