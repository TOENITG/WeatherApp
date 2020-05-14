using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly double Kelvin = 273.15;

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public Task<WeatherReportModel> GetWeatherReport()
        {
            string weatherJSON = "{\"coord\": {\"lon\": 15.21, \"lat\": 59.27}" +
                ",\"weather\": [{\"id\": 802,\"main\": \"Clouds\",\"description\": \"scattered clouds\",\"icon\": \"03d\"}]," +
                "\"base\": \"stations\"," +
                "\"main\": {\"temp\": 284.23,        \"feels_like\": 276.89,        \"temp_min\": 283.15,        \"temp_max\": 285.37,        \"pressure\": 1008,        \"humidity\": 31    },    \"visibility\": 10000,    \"wind\": {        \"speed\": 6.7,        \"deg\": 330    },    \"clouds\": {        \"all\": 50    },    \"dt\": 1589369066,    \"sys\": {        \"type\": 1,        \"id\": 1777,        \"country\": \"SE\",        \"sunrise\": 1589337017,        \"sunset\": 1589397652    },    \"timezone\": 7200,    \"id\": 2686657,    \"name\": \"Örebro\",    \"cod\": 200}";
            string IpAddress = BlazorAppContext.CurrentUserIP;

            WeatherReportModel WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(weatherJSON);
            WeatherReport.Main.Feels_like -= Kelvin;
            WeatherReport.Main.Temp -= Kelvin;

            return Task.FromResult(WeatherReport);
        }

        public WeatherReportModel GetWeather()
        {
            string weatherJSON = "{\"coord\": {\"lon\": 15.21, \"lat\": 59.27},\"weather\": [                {            \"id\": 802,            \"main\": \"Clouds\",            \"description\": \"scattered clouds\",            \"icon\": \"03d\"        }    ],    \"base\": \"stations\",    \"main\": {        \"temp\": 284.23,        \"feels_like\": 276.89,        \"temp_min\": 283.15,        \"temp_max\": 285.37,        \"pressure\": 1008,        \"humidity\": 31    },    \"visibility\": 10000,    \"wind\": {        \"speed\": 6.7,        \"deg\": 330    },    \"clouds\": {        \"all\": 50    },    \"dt\": 1589369066,    \"sys\": {        \"type\": 1,        \"id\": 1777,        \"country\": \"SE\",        \"sunrise\": 1589337017,        \"sunset\": 1589397652    },    \"timezone\": 7200,    \"id\": 2686657,    \"name\": \"Örebro\",    \"cod\": 200}";
            WeatherReportModel WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(weatherJSON);
            return WeatherReport;
        }

    }
}
