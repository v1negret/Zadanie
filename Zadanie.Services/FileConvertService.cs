using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Zadanie.Models;
using Zadanie.Services.Interfaces;
using Zadanie.Services.IO;
using Zadanie.Services.IO.Interfaces;

namespace Zadanie.Services;

public class FileConvertService : IFileConvertService
{
    private readonly IFileReader _fileReader;
    private readonly IDateTimeConverter _dateTimeConverter;

    public FileConvertService()
    {
        _fileReader = new FileReader();
        _dateTimeConverter = new DateTimeConverter();
    }
    
    public List<IpWithDate> ConvertFromDoc(string path)
    {
        var lines = _fileReader.GetLinesFromDoc(path).ToList();

        var list = new List<IpWithDate>();
        string ip;
        string dateTimeString;
        DateTime dateTime;
        Regex regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\b");
        foreach (var line in lines)
        {
            if (!regex.IsMatch(line))
            {
                Console.WriteLine($"Строку {line.Remove(line.IndexOf('\r'))} не удалось преобразовать в нужный формат.");
                continue;
            }
            ip = line.Substring(0, line.IndexOf(':'));
            dateTimeString = line.Substring(line.IndexOf(':')+1).Trim('\r');
            dateTime = _dateTimeConverter.ConvertIn(dateTimeString);
            list.Add(new IpWithDate()
            {
                IpAdress = ip,
                DateTime = dateTime
            });
        }

        return list;
    }
}