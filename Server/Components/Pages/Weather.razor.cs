/*
 * Weather.razor.cs
 *     Created: 2024-06-02T19:56:58-04:00
 *    Modified: 2024-06-02T19:56:58-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Server.Components.Pages;

public partial class Weather
{
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(5000);

        var startDate = date.FromDateTime(datetime.Now);
        var summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };
        forecasts = Enumerable
            .Range(1, 5)
            .Select(
                index =>
                    new WeatherForecast
                    {
                        Date = startDate.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    }
            )
            .ToArray();
    }

    private class WeatherForecast
    {
        public date Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
