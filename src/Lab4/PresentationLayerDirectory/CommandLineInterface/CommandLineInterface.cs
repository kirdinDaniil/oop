using System;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.BllException;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.ServiceException;

namespace Itmo.ObjectOrientedProgramming.Lab4.PresentationLayerDirectory.CommandLineInterface;

public class CommandLineInterface
{
    private Service _service = new Service();

    public void Start()
    {
        while (true)
        {
            string? command = Console.ReadLine();
            if (command is null)
                throw new ArgumentException("line expected");
            try
            {
                _service.ReceiveCommand(command);
                CommandResult commandResult = _service.RunCommand();
                if (commandResult.IsDisconnect)
                    break;
                if (!string.IsNullOrEmpty(commandResult.Result))
                    Console.WriteLine(commandResult.Result);
            }
            catch (ServiceLayerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (BllException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}