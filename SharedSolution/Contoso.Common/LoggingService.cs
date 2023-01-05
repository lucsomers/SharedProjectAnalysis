namespace Contoso.Common;

public class LoggingService : ILoggingService
{
    public void LogInformation(string message)
    {
        Console.WriteLine(message);
    }

    public int GetLogCount()
    {
        return 44;
    }
}