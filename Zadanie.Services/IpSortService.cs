using Zadanie.Models;
using Zadanie.Services.Interfaces;

namespace Zadanie.Services;

public class IpSortService : IIpSortService
{
    private readonly IIpConverter _ipConverter;
    private readonly IDateTimeConverter _dateTimeConverter;

    public IpSortService()
    {
        _ipConverter = new IpConverter();
        _dateTimeConverter = new DateTimeConverter();
    }
    public List<IpWithDate> FindInRadius(List<IpWithDate> ipWithDates, string minBorder, string minDateTime, string maxDateTime)
    {
        List<IpWithDate> result = new List<IpWithDate>();
        var minBorderByteArr = _ipConverter.ToByteArray(minBorder);
        var minDateTimeBorder = _dateTimeConverter.ToUserInFormat(minDateTime);
        var maxDateTimeBorder = _dateTimeConverter.ToUserInFormat(maxDateTime);
        foreach (var ipWithDate in ipWithDates)
        {
            if (ipWithDate.DateTime >= minDateTimeBorder && ipWithDate.DateTime <= maxDateTimeBorder)
            {
                for (int i = 0; i < ipWithDate.IpAdress.Length; i++)
                {
                    if (ipWithDate.IpAdress[i] > minBorderByteArr[i])
                    {
                        result.Add(ipWithDate);
                        break;
                    }
                }
            }
        }

        return result;
    }

    public List<IpWithDate> FindInRadius(List<IpWithDate> ipWithDates, string minBorder, string maxBorder, string minDateTime, string maxDateTime)
    {
        List<IpWithDate> result = new List<IpWithDate>();
        var minBorderByteArr = _ipConverter.ToByteArray(minBorder);
        var maxBorderByteArr = _ipConverter.ToByteArray(maxBorder);
        var minDateTimeBorder = _dateTimeConverter.ConvertIn(minDateTime);
        var maxDateTimeBorder = _dateTimeConverter.ConvertIn(maxDateTime);
        foreach (var ipWithDate in ipWithDates)
        {
            if (ipWithDate.DateTime >= minDateTimeBorder && ipWithDate.DateTime <= maxDateTimeBorder)
            {
                for (int i = 0; i < ipWithDate.IpAdress.Length; i++)
                {
                    if (ipWithDate.IpAdress[i] > minBorderByteArr[i] && ipWithDate.IpAdress[i] < maxBorderByteArr[i])
                    {
                        result.Add(ipWithDate);
                        break;
                    }
                }
            }
        }

        return result;
    }
}