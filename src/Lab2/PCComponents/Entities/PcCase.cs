using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Records;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class PcCase
{
    public PcCase(
        Sizes gpuSize,
        Sizes caseSize,
        IEnumerable<string> formFactor,
        string name)
    {
        GpuSize = gpuSize;
        CaseSize = caseSize;
        FormFactor = formFactor.ToList();
        Name = name;

        ComponentValidator.ValidateObject(gpuSize);

        ComponentValidator.ValidateObject(CaseSize);

        ComponentValidator.ValidateObject(this);
    }

    public PcCase(
        PcCase basePcCase,
        string name,
        Sizes? gpuSize = null,
        Sizes? caseSize = null,
        IEnumerable<string>? formFactor = null)
    {
        if (basePcCase is null)
            throw new PcComponentsException("basePCCase must not be null");
        Name = name;
        GpuSize = gpuSize ?? basePcCase.GpuSize;
        CaseSize = caseSize ?? basePcCase.CaseSize;
        FormFactor = formFactor ?? basePcCase.FormFactor;

        ComponentValidator.ValidateObject(GpuSize);

        ComponentValidator.ValidateObject(CaseSize);

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    public Sizes GpuSize { get; private set; }

    public Sizes CaseSize { get; private set; }

    public IEnumerable<string> FormFactor { get; private set; }

    public PcCase Clone()
    {
        return new PcCase(GpuSize, CaseSize, FormFactor, Name);
    }
}