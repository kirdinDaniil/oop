using DomainModel.Abstractions.CurrentModels;
using DomainModel.Models;

namespace DomainModel.Entities.CurrentModels;

public class CurrentOperation : ICurrentOperation
{
    public IEnumerable<Operation>? Operations { get; set; }
}