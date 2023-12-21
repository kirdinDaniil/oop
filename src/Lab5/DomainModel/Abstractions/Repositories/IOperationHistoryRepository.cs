using DomainModel.Models;

namespace DomainModel.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    public void CreateOperation(int accountId, OperationType type, decimal balance);

    public IEnumerable<Operation> GetOperations(int accountId);
}