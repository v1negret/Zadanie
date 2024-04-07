
using Zadanie.Services;
using Zadanie.Services.Checks;
using Zadanie.Services.Checks.Intrerfaces;
using Zadanie.Services.Interfaces;
using Zadanie.Services.IO;
using Zadanie.Services.IO.Interfaces;

try
{
    IFileConvertService fileConvertService = new FileConvertService();
    IFileWriter fileWriter = new FileWriter();
    IDateTimeChecker _dateTimeChecker = new DateTimeChecker();

    string fileLog = "";
    string fileOutput = "";
    string adressStart = "";
    string adressMask = "";
    string timeStart = "";
    string timeEnd = "";
    if (args.Length > 0)
    {
        for (int i = 0; i < args.Length; i += 2)
        {
            string arg = args[i];
            string argParam = "";
            switch (arg)
            {
                case "--help":
                    Console.WriteLine("""
                                        Список доступных аргументов:
                                        --file-log — путь к файлу с логами. ОБЯЗАТЕЛЬНЫЙ ПАРАМЕТР
                                        --file-output — путь к файлу с результатом. ОБЯЗАТЕЛЬНЫЙ ПАРАМЕТР
                                        --address-start —  нижняя граница диапазона адресов, необязательный параметр, по умолчанию обрабатываются все адреса
                                        --address-mask — маска подсети, задающая верхнюю границу диапазона десятичное число. Необязательный параметр. В случае, если он не указан, обрабатываются все адреса, начиная с нижней границы диапазона. Параметр нельзя использовать, если не задан address-start
                                        --time-start —  нижняя граница временного интервала
                                        --time-end — верхняя граница временного интервала.
                                      """);
                    break;
                case "--file-log":
                    argParam = args[i + 1];
                    fileLog = argParam;
                    if (!File.Exists(argParam))
                    {
                        Console.WriteLine("Файл для параметра --file-log по указанному пути не найден");
                        return;
                    }

                    break;
                case "--file-output":
                    argParam = args[i + 1];
                    fileOutput = argParam;
                    break;
                case "--address-start":
                    argParam = args[i + 1];
                    adressStart = argParam;
                    break;
                case "--address-mask":
                    argParam = args[i + 1];
                    adressMask = argParam;
                    break;
                case "--time-start":
                    argParam = args[i + 1];
                    timeStart = argParam;
                    if (!_dateTimeChecker.IsDateTimeInputValid(timeStart))
                    {
                        Console.WriteLine($"В параметре {arg} неверно задано время или дата");
                        return;
                    }

                    break;
                case "--time-end":
                    argParam = args[i + 1];
                    timeEnd = argParam;
                    if (!_dateTimeChecker.IsDateTimeInputValid(timeEnd))
                    {
                        Console.WriteLine($"В параметре {arg} неверно задано время или дата");
                        return;
                    }

                    break;
                default:
                    Console.WriteLine(
                        $"Параметр {arg} не поддерживается приложением. Скорее всего вы ошиблись. Попробуйте еще раз.");
                    return;
            }
        }

        var dateToIpList = fileConvertService.ConvertFromDoc(fileLog);
        if (String.IsNullOrEmpty(adressMask))
            fileWriter.WriteIpsToFile(dateToIpList, fileOutput, minBorder: adressStart, minDateTime: timeStart,
                maxDateTime: timeEnd);
        else
            fileWriter.WriteIpsToFile(dateToIpList, fileOutput, minBorder: adressStart, maxBorder: adressMask,
                minDateTime: timeStart,
                maxDateTime: timeEnd);
        Console.WriteLine("Программа выполнена успешно");
    }
    else
    {
        Console.WriteLine("Программа работает \n" +
                          "Чтобы узнать подробнее используйте аргумент --help");
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Ошибка доступа. Попробуйте запустить консоль от имени Администратора");
    return;
}