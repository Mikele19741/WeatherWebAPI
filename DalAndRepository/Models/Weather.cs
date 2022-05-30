using System;
using System.Collections.Generic;
using System.Text;

namespace DalAndRepository.Models
{
  public  class Weather
    {
        public short id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
