using DomainModel.Abstractions.CurrentModels;
using DomainModel.Models;

namespace DomainModel.Entities.CurrentModels;

public class CurrentAdmin : ICurrentAdmin
{
    public Admin? Admin { get; set; }
}