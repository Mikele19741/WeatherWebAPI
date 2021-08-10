using DalAndRepository;
using DalAndRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApi.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IForeCast _forecast;
        private readonly IConfiguration _config;
        public string apiUrl { get; set; }
        public string apiKey { get; set; }
        public WeatherController(IForeCast forecast = null, IConfiguration config=null)
        {
            _forecast = forecast;
            _config = config;
        }
        [HttpGet]
        public WeatherInform Get(string Lat, string Lng)
        {
            apiUrl = _config.GetValue<string>(
                  "weatherAPI");
            apiKey = _config.GetValue<string>("weatherAPICode");
            var url= _forecast.GetUrlService(Lat, Lng, apiUrl, apiKey);
            return _forecast.GetInform(url);
        }
    }
}
