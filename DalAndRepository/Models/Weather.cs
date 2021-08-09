using System;
using System.Collections.Generic;
using System.Text;

namespace DalAndRepository.Models
{
  public  class Weather
    {
        public short id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
