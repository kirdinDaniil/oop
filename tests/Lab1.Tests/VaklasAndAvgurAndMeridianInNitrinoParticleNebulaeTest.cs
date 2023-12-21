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

public class VaklasAndAvgurAndMeridianInNitrinoParticleNebulaeTest
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var vaklas = new Vaklas(false);
        var avgur = new Avgur(false);
        var meridian = new Meridian(false);

        var nitrinoParticleNebulae = new NitrinoParticleNebulae(EnvironmentLenght.Small);
        nitrinoParticleNebulae.AddObstacle(new SpaceWhale(1));
        var environments = new List<IEnvironment>();
        environments.Add(nitrinoParticleNebulae);

        var pathSimulationVaklas = new PathSimulation(vaklas, environments);
        var pathSimulationAvgur = new PathSimulation(avgur, environments);
        var pathSimulationMeridian = new PathSimulation(meridian, environments);

        var successImpactResult = new ImpactResult();

        // Act
        PathSimulationResult vaklasResult = pathSimulationVaklas.StartPathSimulation();
        PathSimulationResult avgurResult = pathSimulationAvgur.StartPathSimulation();
        PathSimulationResult meridianResult = pathSimulationMeridian.StartPathSimulation();

        // Assert
        Assert.True(avgurResult.ImpactResult != null && avgurResult.ImpactResult.IsDeflectorDestroyed == true);
        Assert.True(meridianResult.ImpactResult == successImpactResult);
        Assert.True(vaklasResult.ImpactResult != null && vaklasResult.ImpactResult.IsHullDestroyed == true);
    }
}