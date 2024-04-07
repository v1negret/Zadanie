using System.Text;
using Zadanie.Services.Interfaces;

namespace Zadanie.Services;

public class IpConverter : IIpConverter
{
    public byte[] ToByteArray(string ipAdress)
    {
        var numbersList = ipAdress.Split(".");
        byte[] result = new byte[4];
        foreach (var numberString in numbersList)
        {
            int counter = 0;
            result[counter] = byte.Parse(numberString);
        }

        return result;
    }

    public string ToString(byte[] ipAdress)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var number in ipAdress)
        {
            stringBuilder.Append(number + '.');
        }

        stringBuilder.Remove(stringBuilder.Length, 1);
        return stringBuilder.ToString();
    }
}