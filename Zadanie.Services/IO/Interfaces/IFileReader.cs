namespace Zadanie.Services.IO.Interfaces;

public interface IFileReader
{
    public ICollection<string> GetLinesFromDoc(string filePath);
}