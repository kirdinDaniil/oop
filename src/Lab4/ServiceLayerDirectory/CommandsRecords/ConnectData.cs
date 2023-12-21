namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

public record ConnectData(string Address, string Mode) : BaseCommandData;