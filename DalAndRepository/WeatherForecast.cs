using DalAndRepository.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace DalAndRepository
{
    public class WeatherForecast : IForeCast
    {
        public string GetUrlService(string lat, string lng, string api, string key)
        {
            var result = "";
            result = api + "lat=" + lat + "&lon=" + lng + "&" + "appid="+key;
          

            return result;
        }

        public string GetWeather(string url)
        {
        
            
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (var response = webReq.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var text = new StreamReader(responseStream);
                        var res = text.ReadToEnd();
                       return res;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public Main GetMain(string resultString)
        {
            //   var main = new Main();

            var jObject = JObject.Parse(resultString);
            var jItems = jObject["main"];
            var main = JsonConvert.DeserializeObject<Main>(jItems.ToString());

            return main;
        }
        public DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public DateTime GetDate(string resultString)
        {
            var jObject = JObject.Parse(resultString);
            var jItems = jObject["dt"];
            var ticks = (long)jItems;

            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ticks);

        }
        public Sys GetSys(string resultString)
        {
            var jObject = JObject.Parse(resultString);
            var jItems = jObject["sys"];
            var sys = JsonConvert.DeserializeObject<Sys>(jItems.ToString());

            return sys;
        }
        public Wind GetWind(string resultString)
        {

            var jObject = JObject.Parse(resultString);
            var jItems = jObject["wind"];
            var wind = JsonConvert.DeserializeObject<Wind>(jItems.ToString());

            return wind;
        }
        public string GetAthmpsphere(string _atm, string resultString)
        {
            string atm = "";

            var jObject = JObject.Parse(resultString);
            var jItems = jObject[_atm];
            if (jItems != null)
            {
                atm = jItems.ToString().Substring(jItems.ToString().IndexOf(':') + 1);
                atm = atm.Replace(Environment.NewLine, "");
                atm = atm.Replace('}', ' ');
            }
            return atm;
        }
        public List<Weather> GetRain(string resultString)
        {
            var atm = new List<Weather>();
            var jObject = JObject.Parse(resultString);
            var jItems = jObject["weather"];
            if (jObject != null)
            {
                // 
                foreach (var child in jObject["weather"].Children())
                {

                    var res = JsonConvert.SerializeObject(child);
                    var y = JsonConvert.DeserializeObject<Weather>(res);
                    atm.Add(y);
                }



            }
            return atm;
        }

        public string getTimeZone(string resultString)
        {
           
            var jObject = JObject.Parse(resultString);
            var jItems = jObject["name"];
           
            return jItems.ToString();
        }

        public double GetCelicius(double tempKelvin, bool cf)
        {
            if (cf)
                return tempKelvin - 273;
            else
            {
                return 9 / 5 * (tempKelvin - 273) + 32;

            }
        }
        public double GetPressure(double pressure, bool pre)
        {
            if (pre)
            {
                return pressure / 133.3224 * 100;
            }
            else
            {
                return pressure;
            }


        }
       
        public WeatherInform GetInform(string url)
        {
            var result = new WeatherInform();
            
            var weather= GetWeather(url);
            var main = GetMain(weather);


            var sys = GetSys(weather);
            var atm = GetRain(weather);
            if (atm != null)
            {
                foreach (var item in atm)
                {
                    result.Atm += $"{item.description}";
                }

            }

           
            var clouds = "";
            clouds = GetAthmpsphere("clouds", weather);
            var wind = GetWind(weather);
            if (!String.IsNullOrWhiteSpace(clouds))
            {

                result.Cloud = clouds;
            }
            if (wind != null)
            {
                result.Wind = wind;
            }
            if (main != null)
            {
                result.Main = main;
            }
            var tMin = Double.Parse(main.temp_min, new CultureInfo("en-US"));
            var tMax = Double.Parse(main.temp_max, new CultureInfo("en-US"));
            var Temp = Double.Parse(main.temp, new CultureInfo("en-US"));
            var tPresure = Double.Parse(main.pressure, new CultureInfo("en-US"));
            result.MinTemp = GetCelicius(tMin, true);
            result.MaxTemp = GetCelicius(tMax, true);
            result.Temp = GetCelicius(Temp, true);
            result.Pressure = GetPressure(Convert.ToDouble(tPresure), true);
            result.CurrentDateTime = GetDate(weather);
            result.Cloud = clouds;
            var sunset = ConvertFromUnixTimestamp(Convert.ToDouble(sys.sunset)).TimeOfDay;
            var sunrise = ConvertFromUnixTimestamp(Convert.ToDouble(sys.sunrise)).TimeOfDay;
            result.Sunset = $"{sunset.ToString()}(UTC Time)";
            result.Sunrise = $"{ sunrise.ToString()}(UTC Time)";
            result.TimeZone = getTimeZone(weather);

            return result;

        }

    }
}
