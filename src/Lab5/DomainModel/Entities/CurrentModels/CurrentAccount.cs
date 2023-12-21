using DomainModel.Abstractions.CurrentModels;
using DomainModel.Models;

namespace DomainModel.Entities.CurrentModels;

public class CurrentAccount : ICurrentAccount
{
    public Account? Account { get; set; }
}