namespace Console.Abstractions;

public interface IScenario
{
    string Name { get; }

    void Run();
}