using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Records;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class PathSimulationAnalyzer
{
    private PriorityQueue<ISpaceship, double?> _optimalShipQueue;

    private bool _isAnalysisComplete;

    public PathSimulationAnalyzer()
    {
        _optimalShipQueue = new PriorityQueue<ISpaceship, double?>();
        PathSimulations = new List<PathSimulation>();
        _isAnalysisComplete = false;
    }

    public IEnumerable<PathSimulation> PathSimulations { get; private set; }

    public void AddPathSimulation(PathSimulation pathSimulation)
    {
        _isAnalysisComplete = false;
        PathSimulations = PathSimulations.Append(pathSimulation);
    }

    public ISpaceship? GetOptimalSpaceship()
    {
        if (!_isAnalysisComplete)
            StartAnalysis();

        if (_optimalShipQueue.Count > 0)
            return _optimalShipQueue.Peek();

        return null;
    }

    private void StartAnalysis()
    {
        var successImpactResult = new ImpactResult();
        foreach (PathSimulation analyzedPath in PathSimulations)
        {
            PathSimulationResult simulationResult = analyzedPath.StartPathSimulation();
            if (simulationResult.ImpactResult == successImpactResult
                && simulationResult.AccumulatedPathSegmentResult is not null)
            {
                double? overallPriorityPoints = simulationResult.AccumulatedPathSegmentResult.FuelCost;
                _optimalShipQueue.Enqueue(analyzedPath.Spaceship, overallPriorityPoints);
            }
        }

        _isAnalysisComplete = true;
    }
}