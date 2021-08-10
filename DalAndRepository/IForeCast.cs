using DalAndRepository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DalAndRepository
{
    public interface IForeCast
    {

        //  public GoogleTimeZone GetTimeZone(Double Lat, Double Lng);
        public WeatherInform GetInform(string Lat, string Lng);
    }
}
