using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

public record Sizes(
    [property: Range(1, 500)] int Height,
    [property: Range(1, 500)] int Width);