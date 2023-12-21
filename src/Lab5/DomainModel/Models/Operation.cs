namespace DomainModel.Models;

public record Operation(
    int AccountId,
    OperationType Type,
    decimal Balance);