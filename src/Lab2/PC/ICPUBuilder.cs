﻿using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public interface ICpuBuilder
{
    ICpuCoolingBuilder WithCpu(Cpu cpu);
}