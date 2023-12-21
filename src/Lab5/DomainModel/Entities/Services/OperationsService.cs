using DomainModel.Abstractions.Repositories;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Models;

namespace DomainModel.Entities.Services;

public class OperationsService : IOperationsService
{
    private readonly IOperationHistoryRepository _repository;
    private CurrentOperation _currentOperation;

    public OperationsService(IOperationHistoryRepository repository, CurrentOperation currentOperation)
    {
        _repository = repository;
        _currentOperation = currentOperation;
    }

    public void AddOperation(int accountId, OperationType type, decimal balance)
    {
        _repository.CreateOperation(accountId, type, balance);
    }

    public IEnumerable<Operation> GetAccountOperations(int accountId)
    {
        var operations = _repository.GetOperations(accountId).ToList();

        _currentOperation.Operations = operations;

        return operations;
    }
}