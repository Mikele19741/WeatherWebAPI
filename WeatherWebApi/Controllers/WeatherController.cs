using DalAndRepository;
using DalAndRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public WeatherController(IForeCast forecast = null)
        {
            _forecast = forecast;
        }
        [HttpGet]
        public WeatherInform Get()
        {
            var Lat = "56.9460000";
            var Lng = "24.1058900";
            return _forecast.GetInform(Lat, Lng);
        }
    }
}
