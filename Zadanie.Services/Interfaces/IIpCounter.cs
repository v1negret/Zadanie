using Zadanie.Models;

namespace Zadanie.Services.Interfaces;

public interface IIpCounter
{
    public Dictionary<string, int> CountByTime(List<IpWithDate> sortedIpsWithDates);
}