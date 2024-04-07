using Zadanie.Models;

namespace Zadanie.Services.Interfaces;

public interface IIpSortService
{
    public List<IpWithDate> FindInRadius(List<IpWithDate> ipWithDates, string minBorder, string minDateTime, string maxDateTime);
    public List<IpWithDate> FindInRadius(List<IpWithDate> ipWithDates, string minBorder, string maxBorder, string minDateTime, string maxDateTime);
}