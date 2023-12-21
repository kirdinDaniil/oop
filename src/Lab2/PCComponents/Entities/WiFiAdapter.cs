using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents.Entities;

public class WiFiAdapter
{
    public WiFiAdapter(
        string wiFiStandardVersion,
        bool isBluetoothIncluded,
        int pcIeVersion,
        double powerConsumption,
        string name)
    {
        WiFiStandardVersion = wiFiStandardVersion;
        IsBluetoothIncluded = isBluetoothIncluded;
        PcIeVersion = pcIeVersion;
        PowerConsumption = powerConsumption;
        Name = name;
        ComponentValidator.ValidateObject(this);
    }

    public WiFiAdapter(
        WiFiAdapter baseWiFiAdapter,
        string name,
        string? wiFiStandardVersion = null,
        bool? isBluetoothIncluded = null,
        int? pcIeVersion = null,
        double? powerConsumption = null)
    {
        if (baseWiFiAdapter is null)
            throw new PcComponentsException("baseWiFiAdapter must not be null");
        Name = name;
        WiFiStandardVersion = wiFiStandardVersion ?? baseWiFiAdapter.WiFiStandardVersion;
        IsBluetoothIncluded = isBluetoothIncluded ?? baseWiFiAdapter.IsBluetoothIncluded;
        PcIeVersion = pcIeVersion ?? baseWiFiAdapter.PcIeVersion;
        PowerConsumption = powerConsumption ?? baseWiFiAdapter.PowerConsumption;

        ComponentValidator.ValidateObject(this);
    }

    [Required(AllowEmptyStrings = false)]
    public string Name { get; private set; }

    [Required(AllowEmptyStrings = false)]
    public string WiFiStandardVersion { get; private set; }

    public bool IsBluetoothIncluded { get; private set; }

    [Range(1, 10)]
    public int PcIeVersion { get; private set; }

    [Range(1, 20)]
    public double PowerConsumption { get; private set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(WiFiStandardVersion, IsBluetoothIncluded, PcIeVersion, PowerConsumption, Name);
    }
}