using Zadanie.Models;
using Zadanie.Services.Interfaces;

namespace Zadanie.Services;

public class IpCounter : IIpCounter
{
    public Dictionary<string, int> CountByTime(List<IpWithDate> sortedIpsWithDates)
    {
        if (sortedIpsWithDates.Count == 0) return null;
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        for (int i = 0; i < sortedIpsWithDates.Count; i++)
        {
            if (result.ContainsKey(sortedIpsWithDates[i].IpAdress)) continue;
            
            var buffer = sortedIpsWithDates[i].IpAdress;
            var counter = 0;
            for (int j = 1; j < sortedIpsWithDates.Count; j++)
            {
                if (buffer.Equals(sortedIpsWithDates[j].IpAdress))
                {
                    counter++;
                }
            }
            result.Add(buffer, counter);
        }

        result[sortedIpsWithDates[0].IpAdress] += 1;
        return result;
    }
}