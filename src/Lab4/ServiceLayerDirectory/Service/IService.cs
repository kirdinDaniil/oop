using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service;

public interface IService
{
    public CommandResult RunCommand();
}