namespace Console.Entities;

public record ScenarioSubOperation
{
    public ScenarioSubOperation(OperationDel operationMethod, string name)
    {
        OperationMethod = operationMethod;
        Name = name;
    }

    public delegate void OperationDel();

    public OperationDel OperationMethod { get; init; }

    public string Name { get; init; }
}