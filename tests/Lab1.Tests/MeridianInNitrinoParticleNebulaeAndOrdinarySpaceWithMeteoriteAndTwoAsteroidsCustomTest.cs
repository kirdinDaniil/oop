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

public class MeridianInNitrinoParticleNebulaeAndOrdinarySpaceWithMeteoriteAndTwoAsteroidsCustomTest
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var meridian = new Meridian(false);

        var nitrinoParticleNebulae = new NitrinoParticleNebulae(EnvironmentLenght.Small);

        var ordinarySpace = new OrdinarySpace(EnvironmentLenght.Small);
        ordinarySpace.AddObstacle(new Meteorite());
        ordinarySpace.AddObstacle(new Asteroid());
        ordinarySpace.AddObstacle(new Asteroid());

        var environments = new List<IEnvironment>();
        environments.Add(nitrinoParticleNebulae);
        environments.Add(ordinarySpace);

        var pathSimulationMeridian = new PathSimulation(meridian, environments);

        var successImpactResult = new ImpactResult();

        // Act
        PathSimulationResult meridianResult = pathSimulationMeridian.StartPathSimulation();

        // Assert
        Assert.True(meridianResult.ImpactResult == successImpactResult);
    }
}