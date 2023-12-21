namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

public record FileRenameData(string Path, string FileName) : BaseCommandData;
