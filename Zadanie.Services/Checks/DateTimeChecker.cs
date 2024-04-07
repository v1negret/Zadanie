using System.Globalization;
using Zadanie.Services.Checks.Intrerfaces;
using Zadanie.Services.Interfaces;

namespace Zadanie.Services.Checks;

public class DateTimeChecker : IDateTimeChecker
{
    private readonly IDateTimeConverter _dateTimeConverter;

    public DateTimeChecker()
    {
        _dateTimeConverter = new DateTimeConverter();
    }
    public bool IsDateTimeInputValid(string dateTimeString)
    {
        DateTime buffer;
        if (!DateTime.TryParseExact(dateTimeString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out buffer)
            &&
            !DateTime.TryParseExact(dateTimeString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out buffer))
        {
            return false;
        }

        return true;
    }
}