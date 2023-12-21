using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public interface IPermanentMemoryBuilder
{
    IPcBuilder WithPermanentMemory(IEnumerable<IPermanentMemory> permanentMemory);
}