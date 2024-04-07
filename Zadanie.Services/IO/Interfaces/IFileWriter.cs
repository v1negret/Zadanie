using Zadanie.Models;

namespace Zadanie.Services.IO.Interfaces;

public interface IFileWriter
{
    public bool WriteIpsToFile(List<IpWithDate> ipsWithDates, string filePath, string minBorder, string minDateTime, string maxDateTime);
    public bool WriteIpsToFile(List<IpWithDate> ipsWithDates, string filePath, string minBorder, string maxBorder, string minDateTime, string maxDateTime);
}