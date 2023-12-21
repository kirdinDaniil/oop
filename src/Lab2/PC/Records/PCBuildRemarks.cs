using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PC.Records;

public record PCBuildRemarks(
    bool IsPcValid,
    bool IsWarrantyInclude,
    IEnumerable<string> Remarks);