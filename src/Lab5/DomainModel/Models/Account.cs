namespace DomainModel.Models;

public record Account(
    int Id,
    string Name,
    int Pin,
    decimal Balance,
    bool IsActive);