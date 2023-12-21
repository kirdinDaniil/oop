namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

public record FileMoveData(string SourcePath, string DestinationPath) : BaseCommandData;