using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

public record Chipset(
    [property: Range(500, 10000)] int MaxRAMFrequency,
    bool IsXPMSupports);