using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Constants;
using Itmo.ObjectOrientedProgramming.Lab2.PC.Records;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Entities;

public class Pc
{
    private Pc(
        Motherboard? motherboard,
        Cpu? cpu,
        CpuCoolingSystem? cpuCoolingSystem,
        IEnumerable<Ram>? ram,
        IEnumerable<IPermanentMemory>? permanentMemory,
        PcCase? pcCase,
        PowerSupply? powerSupply,
        WiFiAdapter? wiFiAdapter,
        Gpu? gpu,
        PCBuildRemarks buildRemarks)
    {
        if (motherboard is null || cpu is null || cpuCoolingSystem is null || ram is null || permanentMemory is null ||
            pcCase is null || powerSupply is null)
            throw new PcComponentsException("PC does not contain required components");
        Motherboard = motherboard;
        Cpu = cpu;
        CpuCoolingSystem = cpuCoolingSystem;
        Ram = ram;
        PermanentMemory = permanentMemory;
        PcCase = pcCase;
        PowerSupply = powerSupply;
        WiFiAdapter = wiFiAdapter;
        Gpu = gpu;
        BuildRemarks = buildRemarks;
    }

    public static IMotherboardBuilder Builder => new PcBuilder();

    public Motherboard Motherboard { get; private set; }

    public Cpu Cpu { get; private set; }

    public CpuCoolingSystem CpuCoolingSystem { get; private set; }

    public IEnumerable<Ram> Ram { get; private set; }

    public IEnumerable<IPermanentMemory> PermanentMemory { get; private set; }

    public PcCase PcCase { get; private set; }

    public PowerSupply PowerSupply { get; private set;  }

    public WiFiAdapter? WiFiAdapter { get; private set; }

    public Gpu? Gpu { get; private set; }

    public PCBuildRemarks BuildRemarks { get; private set; }

    public Pc Clone()
    {
        var clonedRam = new List<Ram>();
        foreach (Ram ramForClone in Ram)
        {
            clonedRam.Add(ramForClone.Clone());
        }

        var clonedPermanentMemory = new List<IPermanentMemory>();
        foreach (IPermanentMemory permanentMemoryForClone in PermanentMemory)
        {
            clonedPermanentMemory.Add(permanentMemoryForClone.Clone());
        }

        return new Pc(
            Motherboard.Clone(),
            Cpu.Clone(),
            CpuCoolingSystem.Clone(),
            clonedRam,
            clonedPermanentMemory,
            PcCase.Clone(),
            PowerSupply.Clone(),
            WiFiAdapter?.Clone(),
            Gpu?.Clone(),
            BuildRemarks);
    }

    private class PcBuilder : ICpuBuilder, ICpuCoolingBuilder, IMotherboardBuilder, IPcBuilder,
        IPermanentMemoryBuilder, IRamBuilder
    {
        private Motherboard? _motherboard;
        private Cpu? _cpu;
        private CpuCoolingSystem? _cpuCoolingSystem;
        private List<Ram>? _ram;
        private List<IPermanentMemory>? _permanentMemory;
        private PcCase? _pcCase;
        private PowerSupply? _powerSupply;
        private WiFiAdapter? _wiFiAdapter;
        private Gpu? _gpu;
        private bool _isPcValid = true;
        private bool _isWarrantyInclude = true;
        private List<string> _remarks = new List<string>();
        public ICpuCoolingBuilder WithCpu(Cpu cpu)
        {
            _cpu = cpu;
            if (_motherboard is null)
                throw new PcComponentsException("Motherboard is null");

            if (_cpu.Socket != _motherboard.Socket)
            {
                _isPcValid = false;
                _remarks.Add("Motherboard and processor sockets do not match");
            }

            if (_motherboard.CurrentBios.SupportedCpuNames.Any(cpuName => cpuName == cpu.Name)) return this;
            _isPcValid = false;
            _remarks.Add("Cpu is not supported by this version of the bios");

            return this;
        }

        public IRamBuilder WithCpuCooling(CpuCoolingSystem cpuCoolingSystem)
        {
            _cpuCoolingSystem = cpuCoolingSystem;

            if (_cpu is null)
                throw new PcComponentsException("Cpu is null");

            if (_cpuCoolingSystem.Tdp < _cpu.Tdp)
            {
                _isWarrantyInclude = false;
                _remarks.Add("Denial of warranty due to insufficient cooling system heat dissipation for the current processor");
            }

            if (_cpuCoolingSystem.SupportedSockets.Any(coolingSystemSocket => coolingSystemSocket == _cpu.Socket))
                return this;
            _isPcValid = false;
            _remarks.Add("The socket on the motherboard does not support this cooling system");

            return this;
        }

        public ICpuBuilder WithMotherboard(Motherboard motherboard)
        {
            _motherboard = motherboard;

            return this;
        }

        public IPcBuilder GetWithGpu(Gpu gpu)
        {
            _gpu = gpu;

            return this;
        }

        public IPcBuilder WithWiFiAdapter(WiFiAdapter wiFiAdapter)
        {
            _wiFiAdapter = wiFiAdapter;

            return this;
        }

        public Pc Build()
        {
            if (_ram is null)
                throw new PcComponentsException("Ram is null");
            if (_permanentMemory is null)
                throw new PcComponentsException("PermanentMemory is null");
            if (_cpu is null)
                throw new PcComponentsException("Cpu is null");

            double totalPowerConsumption = _permanentMemory.Sum(drive => drive.PowerConsumption)
                                           + _ram.Sum(currentRam => currentRam.PowerConsumption);

            totalPowerConsumption += _wiFiAdapter?.PowerConsumption ?? 0;
            totalPowerConsumption += _gpu?.PowerConsumption ?? 0;
            totalPowerConsumption += _cpu.Tdp;
            if (totalPowerConsumption > _powerSupply?.Power)
            {
                _remarks.Add("The power supply has insufficient power");
            }

            if (_gpu is null && !_cpu.IsGraphicsIntegrated)
            {
                _isPcValid = false;
                _remarks.Add("PC must contain graphic processor");
            }

            if (_permanentMemory.Count == 0)
            {
                _isPcValid = false;
                _remarks.Add("PC must contain permanent memory storage");
            }

            if (_ram.Count == 0)
            {
                _isPcValid = false;
                _remarks.Add("PC must contain RAM");
            }

            return new Pc(
                _motherboard,
                _cpu,
                _cpuCoolingSystem,
                _ram,
                _permanentMemory,
                _pcCase,
                _powerSupply,
                _wiFiAdapter,
                _gpu,
                new PCBuildRemarks(_isPcValid, _isWarrantyInclude, _remarks));
        }

        public IPcBuilder WithCase(PcCase pcCase)
        {
            _pcCase = pcCase;
            if (_motherboard is null)
                throw new PcComponentsException("Motherboard is null");

            if (_pcCase.FormFactor.All(form => form != _motherboard.FormFactor))
            {
                _isPcValid = false;
                _remarks.Add("The form factor of the case does not support the motherboard");
            }

            if (_gpu == null ||
                (_pcCase.GpuSize.Height >= _gpu.Size.Height && _pcCase.GpuSize.Width >= _gpu.Size.Width)) return this;
            _isPcValid = false;
            _remarks.Add("Sizes of the GPU are not supported by the case");

            return this;
        }

        public IPcBuilder WithPermanentMemory(IEnumerable<IPermanentMemory> permanentMemory)
        {
            _permanentMemory = permanentMemory.ToList();

            return this;
        }

        public IPcBuilder WithPowerSupply(PowerSupply powerSupply)
        {
            _powerSupply = powerSupply;

            return this;
        }

        public IPermanentMemoryBuilder WithRam(IEnumerable<Ram> ram)
        {
            _ram = ram.ToList();
            if (_cpu is null)
                throw new PcComponentsException("Cpu is null");
            if (_motherboard is null)
                throw new PcComponentsException("Motherboard is null");

            int minFrequency = (from currentRam in _ram from frequency in currentRam.Frequencies select frequency.JEDECFrequency).Prepend(PCConstants.MaxRAMFrequency).Min();

            if (minFrequency > _cpu.MaxRamFrequency)
            {
                _isPcValid = false;
                _remarks.Add("Frequencies of this RAM are not supported by the CPU");
            }

            if (_ram.Count > _motherboard.RamSlots)
            {
                _isPcValid = false;
                _remarks.Add("Not enough slots on the motherboard for RAM");
            }

            if (!_ram.Any(r => r.Ddr != _motherboard.SupportedDdr)) return this;
            _isPcValid = false;
            _remarks.Add("RAM generation is not supported by motherboard");

            return this;
        }
    }
}