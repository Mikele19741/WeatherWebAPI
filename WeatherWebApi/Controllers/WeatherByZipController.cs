using DalAndRepository;
using DalAndRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Controllers
{
    [Route("api/weatherbyzipcode")]
    [ApiController]
    public class WeatherByZipController : ControllerBase
    {
        private readonly IForeCast _forecast;
        private readonly IConfiguration _config;
        public string apiUrl { get; set; }
        public string apiKey { get; set; }
        public WeatherByZipController(IForeCast forecast = null, IConfiguration config = null)
        {
            _forecast = forecast;
            _config = config;
        }
        [HttpGet]
        public WeatherOfCitiy Get(string zip)
        {
            apiUrl = _config.GetValue<string>(
                  "weatherAPI");
            apiKey = _config.GetValue<string>("weatherAPICode");
            var url = _forecast.GetUrlServiceZipCode(zip, apiUrl, apiKey);
            return _forecast.GetInformWeather(url);
        }
    }
}
