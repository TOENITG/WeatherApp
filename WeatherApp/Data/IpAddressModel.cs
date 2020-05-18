using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Data
{
    public class IpAddressModel
    {
        private Microsoft.AspNetCore.Http.HttpContext httpContext;
        public string IpAddress { get
            { return httpContext.Connection.RemoteIpAddress.ToString();  }
        }
    }
}
