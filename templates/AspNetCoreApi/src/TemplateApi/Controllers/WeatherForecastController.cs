using Microsoft.AspNetCore.Mvc;

namespace TemplateApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly List<string> Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly List<WeatherForecast> _forecastItems;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _forecastItems = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Count)]
        }).ToList();
    }

    [HttpGet()]
    public Task<IEnumerable<WeatherForecast>> Get()
    {
        return Task.FromResult<IEnumerable<WeatherForecast>>(_forecastItems);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        if (_forecastItems.Count < id)
        {
            return BadRequest();
        }

        return Ok(_forecastItems[id]);
    }

    [HttpPost()]
    public IActionResult Create([FromBody] WeatherCreateModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Summary))
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPut()]
    public IActionResult Update([FromBody] WeatherUpdateModel model)
    {
        if (_forecastItems.Count < model.Index && model.Index >= 0)
        {
            return BadRequest();
        }

        _forecastItems[model.Index].Summary = model.Summary;

        return Ok(_forecastItems[model.Index]);
    }

    [HttpDelete("{id:int}/")]
    public IActionResult Delete(int id)
    {
        if (_forecastItems.Count < id && id >= 0)
        {
            return BadRequest();
        }

        _forecastItems.RemoveAt(id);

        return Ok();
    }
}

public class WeatherUpdateModel
{
    public int Index { get; set; }
    public required string Summary { get; set; }
}

public class WeatherCreateModel
{
    public required string Summary { get; set; }
}

