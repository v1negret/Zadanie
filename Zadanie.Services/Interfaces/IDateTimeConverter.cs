using System.Runtime.InteropServices.JavaScript;

namespace Zadanie.Services.Interfaces;

public interface IDateTimeConverter
{
    public DateTime ConvertIn(string dateTime);
    public string ConvertOut(DateTime dateTime);
    public DateTime ToUserInFormat(string dateTime);
}