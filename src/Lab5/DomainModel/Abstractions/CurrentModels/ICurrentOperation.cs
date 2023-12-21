using DomainModel.Models;

namespace DomainModel.Abstractions.CurrentModels;

public interface ICurrentOperation
{
    public IEnumerable<Operation>? Operations { get; }
}