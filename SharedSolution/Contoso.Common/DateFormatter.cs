namespace Contoso.Common;

public class DateFormatter
{
    // 2 Usages, 1 in BackendSolution, 1 in TestingSolution
    public static string GetShortDateString(DateTime dateTime)
    {
        return dateTime.ToShortDateString();
    }
}