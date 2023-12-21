using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShuttleAndVaklasInNitrinoParticleNebulae
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var shuttle = new Shuttle();
        var vaklas = new Vaklas(false);

        ISpaceship? optimalSpaceship;

        var nitrinoParticleNebulae = new NitrinoParticleNebulae(EnvironmentLenght.Normal);
        var environments = new List<IEnvironment>();
        environments.Add(nitrinoParticleNebulae);

        var pathSimulationShuttle = new PathSimulation(shuttle, environments);
        var pathSimulationVaklas = new PathSimulation(vaklas, environments);

        var pathSimulationAnalyzer = new PathSimulationAnalyzer();

        // Act
        pathSimulationAnalyzer.AddPathSimulation(pathSimulationShuttle);
        pathSimulationAnalyzer.AddPathSimulation(pathSimulationVaklas);
        optimalSpaceship = pathSimulationAnalyzer.GetOptimalSpaceship();

        // Assert
        Assert.True(optimalSpaceship is Vaklas);
    }
}