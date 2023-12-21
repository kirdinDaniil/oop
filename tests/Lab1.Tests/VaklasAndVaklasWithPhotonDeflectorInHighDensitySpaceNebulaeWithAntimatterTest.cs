using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VaklasAndVaklasWithPhotonDeflectorInHighDensitySpaceNebulaeWithAntimatterTest
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var vaklas = new Vaklas(false);
        var vaklasWithPhotonDeflector = new Vaklas(true);

        var highDensitySpaceNebulae = new HighDensitySpaceNebulae(EnvironmentLenght.Small);
        highDensitySpaceNebulae.AddObstacle(new AntimatterFlares());
        var environments = new List<IEnvironment>();
        environments.Add(highDensitySpaceNebulae);

        var pathSimulationVaklas = new PathSimulation(vaklas, environments);
        var pathSimulationVaklasWithPhotonDeflector = new PathSimulation(vaklasWithPhotonDeflector, environments);

        var successImpactResult = new ImpactResult();

        // Act
        PathSimulationResult vaklasResult = pathSimulationVaklas.StartPathSimulation();
        PathSimulationResult vaklasWithPhotonDeflectoResult = pathSimulationVaklasWithPhotonDeflector.StartPathSimulation();

        // Assert
        Assert.True(vaklasResult.ImpactResult != successImpactResult);
        Assert.True(vaklasWithPhotonDeflectoResult.ImpactResult == successImpactResult);
    }
}