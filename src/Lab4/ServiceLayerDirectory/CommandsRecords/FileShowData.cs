namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

public record FileShowData(string Path, string? Mode) : BaseCommandData;