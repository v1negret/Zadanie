
using Zadanie.Services.IO.Interfaces;

namespace Zadanie.Services.IO;

public class FileReader : IFileReader
{
    public ICollection<string> GetLinesFromDoc(string filePath)
    {
        if (File.Exists(filePath))
        {
            var result = new List<string>();
            using (var file = new StreamReader(filePath))
            {
                result = file.ReadToEndAsync().Result.Split('\n').ToList();
            }

            return result;
        }

        throw new FileNotFoundException();
    }
}