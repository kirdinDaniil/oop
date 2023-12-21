using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

public record RamFrequency(
    [property: Range(500, 5000)] int JEDECFrequency,
    [property: Range(0, 10)] double Voltage);