using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class IpAddressInfoModel
    {
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_name { get; set; }
        public string city_name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string isp { get; set; }
        public int credits_consumed { get; set; }
    }
}
