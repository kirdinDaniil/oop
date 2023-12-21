using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enums;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class AvgurAndStellaInHighDensitySpaceNebulaeTest
{
    [Fact]
    public void SimulatePath()
    {
        // Arrange
        var avgur = new Avgur(false);
        var stella = new Stella(false);

        ISpaceship? optimalSpaceship;

        var highDensitySpaceNebulae = new HighDensitySpaceNebulae(EnvironmentLenght.Normal);
        var environments = new List<IEnvironment>();
        environments.Add(highDensitySpaceNebulae);

        var pathSimulationAvgur = new PathSimulation(avgur, environments);
        var pathSimulationStella = new PathSimulation(stella, environments);

        var pathSimulationAnalyzer = new PathSimulationAnalyzer();

        // Act
        pathSimulationAnalyzer.AddPathSimulation(pathSimulationAvgur);
        pathSimulationAnalyzer.AddPathSimulation(pathSimulationStella);
        optimalSpaceship = pathSimulationAnalyzer.GetOptimalSpaceship();

        // Assert
        Assert.True(optimalSpaceship is Stella);
    }
}