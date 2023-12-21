namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

public record FileCopyData(string SourcePath, string DestinationPath) : BaseCommandData;