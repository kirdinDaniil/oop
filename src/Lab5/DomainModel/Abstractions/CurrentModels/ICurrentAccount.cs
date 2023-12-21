using DomainModel.Models;

namespace DomainModel.Abstractions.CurrentModels;

public interface ICurrentAccount
{
    public Account? Account { get; }
}