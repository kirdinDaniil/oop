using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public interface IRamBuilder
{
    IPermanentMemoryBuilder WithRam(IEnumerable<Ram> ram);
}