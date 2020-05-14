using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
        private static readonly string IPInfoAPIToken = "CCYTBD2Q3D";
        private static readonly string WeaterAPIToken = "345a23db5416c932e14dab8b194ba755";

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

        public IpAddressInfoModel GetIpAddressInfo(string IPAddress)
        {
            string IpJson = "{\"country_code\":\"SE\",\"country_name\":\"Sweden\",\"region_name\":\"Orebro lan\"" +
                ",\"city_name\":\"Orebro\",\"latitude\":\"59.27412\",\"longitude\":\"15.2066\"" +
                ",\"isp\":\"Com Hem AB\",\"credits_consumed\":4}";

            IpAddressInfoModel ipAddressInfo = JsonConvert.DeserializeObject<IpAddressInfoModel>(IpJson);
            return ipAddressInfo;
        }
    
        public async Task<WeatherReportModel> GetWeatherReport()
        {
            string weatherJSON = "{\"coord\": {\"lon\": 15.21, \"lat\": 59.27}" +
                ",\"weather\": [{\"id\": 802,\"main\": \"Clouds\",\"description\": \"scattered clouds\",\"icon\": \"03d\"}]," +
                "\"base\": \"stations\"," +
                "\"main\": {\"temp\": 284.23,        \"feels_like\": 276.89,        \"temp_min\": 283.15,        \"temp_max\": 285.37,        \"pressure\": 1008,        \"humidity\": 31    },    \"visibility\": 10000,    \"wind\": {        \"speed\": 6.7,        \"deg\": 330    },    \"clouds\": {        \"all\": 50    },    \"dt\": 1589369066,    \"sys\": {        \"type\": 1,        \"id\": 1777,        \"country\": \"SE\",        \"sunrise\": 1589337017,        \"sunset\": 1589397652    },    \"timezone\": 7200,    \"id\": 2686657,    \"name\": \"Örebro\",    \"cod\": 200}";
            string IpAddress = BlazorAppContext.CurrentUserIP;

            var ipAddressInfo = GetIpAddressInfo(IpAddress);

            WeatherReportModel WeatherReport = new WeatherReportModel();

            // Fetch Weather data from API into JSON string and convert to object.

            var httpClient = HttpClientFactory.Create();
            var url = "https://api.openweathermap.org/data/2.5/weather?lat=59.27412&lon=15.2066&appid=345a23db5416c932e14dab8b194ba755";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(data);
    //            WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(weatherJSON);
                WeatherReport.Main.Feels_like -= Kelvin;
                WeatherReport.Main.Temp -= Kelvin;

                return WeatherReport;
            }
            return null;
        }

        public WeatherReportModel GetWeather()
        {
            string weatherJSON = "{\"coord\": {\"lon\": 15.21, \"lat\": 59.27},\"weather\": [                {            \"id\": 802,            \"main\": \"Clouds\",            \"description\": \"scattered clouds\",            \"icon\": \"03d\"        }    ],    \"base\": \"stations\",    \"main\": {        \"temp\": 284.23,        \"feels_like\": 276.89,        \"temp_min\": 283.15,        \"temp_max\": 285.37,        \"pressure\": 1008,        \"humidity\": 31    },    \"visibility\": 10000,    \"wind\": {        \"speed\": 6.7,        \"deg\": 330    },    \"clouds\": {        \"all\": 50    },    \"dt\": 1589369066,    \"sys\": {        \"type\": 1,        \"id\": 1777,        \"country\": \"SE\",        \"sunrise\": 1589337017,        \"sunset\": 1589397652    },    \"timezone\": 7200,    \"id\": 2686657,    \"name\": \"Örebro\",    \"cod\": 200}";
            WeatherReportModel WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(weatherJSON);
            WeatherReport.Main.Feels_like -= Kelvin;
            WeatherReport.Main.Temp -= Kelvin;
            return WeatherReport;
        }

    }
}
