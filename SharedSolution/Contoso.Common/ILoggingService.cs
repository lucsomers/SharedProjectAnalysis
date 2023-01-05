namespace Contoso.Common;

public interface ILoggingService
{
    // 1 usage in BackendSolution
    public void LogInformation(string message);
    
    // 0 usages
    public int GetLogCount();
}