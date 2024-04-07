using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Metrics;
using Zadanie.Models;
using Zadanie.Services.Interfaces;
using Zadanie.Services.IO.Interfaces;

namespace Zadanie.Services.IO;

public class FileWriter : IFileWriter
{
    private readonly IIpSortService _ipSortService;
    private readonly IIpCounter _ipCounter;
    public FileWriter()
    {
        _ipSortService = new IpSortService();
        _ipCounter = new IpCounter();
    }
    public bool WriteIpsToFile(List<IpWithDate> ipsWithDates,string filePath, string minBorder, string minDateTime, string maxDateTime)
    {
        var sortedIps = _ipSortService.FindInRadius(ipsWithDates, minBorder: minBorder, minDateTime:minDateTime, maxDateTime:maxDateTime);
        var ipCount = _ipCounter.CountByTime(sortedIps);
        using (var streamWriter = new StreamWriter(filePath, append:true))
        {
            streamWriter.WriteLineAsync($"-----ЗАПРОС ОТ {DateTime.Now}-----------------");
            foreach (var ip in ipCount)
            { 
                streamWriter.WriteLineAsync($"{ip.Key} - {ip.Value} запросов.");
            }
        }

        return true;
    }
    
    public bool WriteIpsToFile(List<IpWithDate> ipsWithDates, string filePath, string minBorder, string maxBorder, string minDateTime, string maxDateTime)
    {
        var sortedIps = _ipSortService.FindInRadius(ipsWithDates, minBorder: minBorder, maxBorder: maxBorder, minDateTime:minDateTime, maxDateTime:maxDateTime);
        var ipCount = _ipCounter.CountByTime(sortedIps);
        using (var streamWriter = new StreamWriter(filePath, append:true))
        {
            streamWriter.WriteLineAsync($"-----ЗАПРОС ОТ {DateTime.Now}-----------------");
            foreach (var ip in ipCount)
            { 
                streamWriter.WriteAsync($"{ip.Key} - {ip.Value} запросов.");
            }
        }

        return true;
    }
}