using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpContextAccessor _httpContextAccssor;
        public WeatherForecastService(IHttpContextAccessor httpContextAccssor)
        {
            _httpContextAccssor = httpContextAccssor;
        }
    
        public string UserAgent { get; set; }
        public string IPAddress { get; set; }
        
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
            //      IPAddress = _httpContextAccssor.HttpContext.Connection.RemoteIpAddress.ToString();
            IPAddress = "";

            var ipAddressInfo = GetIpAddressInfo(IPAddress);

            WeatherReportModel WeatherReport = new WeatherReportModel();

            var httpClient = HttpClientFactory.Create();
            var url = "https://api.openweathermap.org/data/2.5/weather?lat=59.27412&lon=15.2066&appid=345a23db5416c932e14dab8b194ba755";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();
                WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(data);
                WeatherReport.Main.Feels_like -= Kelvin;
                WeatherReport.Main.Temp -= Kelvin;
                return WeatherReport;
            }
            return null;
        }
        public WeatherReportModel GetWeather()
        {
            IPAddress = _httpContextAccssor.HttpContext.Connection.RemoteIpAddress.ToString();
    
            var ipAddressInfo = GetIpAddressInfo(IPAddress);

            WeatherReportModel WeatherReport = new WeatherReportModel();

            var httpClient = HttpClientFactory.Create();
            var url = "https://api.openweathermap.org/data/2.5/weather?lat=59.27412&lon=15.2066&appid=345a23db5416c932e14dab8b194ba755";
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = content.ReadAsStringAsync();
                WeatherReport = JsonConvert.DeserializeObject<WeatherReportModel>(data.Result);
                WeatherReport.Main.Feels_like -= Kelvin;
                WeatherReport.Main.Temp -= Kelvin;
                return WeatherReport;
            }
            return null;
        }
    }
}
