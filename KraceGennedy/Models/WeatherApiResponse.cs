using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class WeatherApiResponse
    {
        public string name { get; set; }
        public int id { get; set; }
        public int cod { get; set; }
        public int timezone { get; set; }
        public Coord coord { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
        //public string base { get; set;}

    }

    public class List
    {
        public int dt { get; set; }
        public List<Weather> weather { get; set; }
        public string dt_txt { get; set; }
    }

    public class City {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
    }

    
        

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Coord
    {
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }
}
