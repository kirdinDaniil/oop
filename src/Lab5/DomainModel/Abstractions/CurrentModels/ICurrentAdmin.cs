using DomainModel.Models;

namespace DomainModel.Abstractions.CurrentModels;

public interface ICurrentAdmin
{
    public Admin? Admin { get; }
}