using System.Globalization;
using Zadanie.Services.Interfaces;

namespace Zadanie.Services;

public class DateTimeConverter : IDateTimeConverter
{
    public DateTime ConvertIn(string dateTime) => DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

    public string ConvertOut(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

    public DateTime ToUserInFormat(string dateTime)
    {
        DateTime result;
        bool tryResult;
        tryResult = DateTime.TryParseExact(dateTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out result);
        if(!tryResult){
            tryResult = DateTime.TryParseExact(dateTime, "HH:mm:ss dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out result);
        }

        return result;
    }
    
}