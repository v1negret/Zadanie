using Zadanie.Models;

namespace Zadanie.Services.Interfaces;

public interface IFileConvertService
{
    public List<IpWithDate> ConvertFromDoc(string path);
}