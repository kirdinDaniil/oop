using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC;

public interface IPcBuilder
{
    IPcBuilder GetWithGpu(Gpu gpu);

    IPcBuilder WithWiFiAdapter(WiFiAdapter wiFiAdapter);

    IPcBuilder WithPowerSupply(PowerSupply powerSupply);

    IPcBuilder WithCase(PcCase pcCase);

    Entities.Pc Build();
}