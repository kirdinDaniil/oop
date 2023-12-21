using DomainModel.Models;

namespace DomainModel.Abstractions.Services;

public interface IOperationsService
{
    public void AddOperation(int accountId, OperationType type, decimal balance);

    public IEnumerable<Operation> GetAccountOperations(int accountId);
}