using Contoso.Common;

namespace Contoso.Tests;

public class DateFormatterTests
{

    [Test]
    public void Test1()
    {
        // Arrange
        DateTime date = DateTime.Now;

        // Act
        string formattedDate = DateFormatter.GetShortDateString(date);

        // Assert
        Assert.That(formattedDate, Is.EqualTo(date.ToShortDateString()));
    }
}