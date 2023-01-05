using Contoso.Common;

namespace Contoso.Tests;

public class DateFormatterTests
{

    [Test]
    public void Test1()
    {
        // Arrange
        var date = DateTime.Now;
        
        // Act
        var formattedDate = DateFormatter.GetShortDateString(date);
            
        // Assert
        Assert.That(formattedDate, Is.EqualTo(date.ToShortDateString()));
    }
}