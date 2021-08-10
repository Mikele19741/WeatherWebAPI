using DalAndRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DalAndRepository
{
    public interface IForeCast
    {

        public string GetUrlService(string lat, string lng, string api, string key);
        public WeatherInform GetInform(string url);
    }
}
