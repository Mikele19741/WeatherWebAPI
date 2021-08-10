using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DalAndRepository.Models
{
   public class WeatherInform
    {
        public DateTime CurrentDateTime { get; set; }
        [DefaultValue(0)]
        public double MinTemp { get; set; }
        [DefaultValue(0)]
        public double MaxTemp { get; set; }
        [DefaultValue(0)]
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public Wind Wind { get; set; }
        public Main Main { get; set; }
        [DefaultValue("")]
        public string Atm { get; set; }
        [DefaultValue("")]
        public string Cloud { get; set; }
        [DefaultValue("")]
        public string Sunrise { get; set; }
        [DefaultValue("")]
        public string Sunset { get; set; }

        public string TimeZone { get; set; }
    }
}
