using Contoso.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILoggingService _loggingService;

    public WeatherForecastController(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _loggingService.LogInformation("Getting weather forecast!");
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = DateFormatter.GetShortDateString(DateTime.Now)
            })
            .ToArray();
    }
}