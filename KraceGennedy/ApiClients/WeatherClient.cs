using KraceGennedy.Interfaces;
using KraceGennedy.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KraceGennedy.ApiClients
{
    public class WeatherClient : IWeatherInterface
    {
        private IConfiguration configuration;
        private readonly JsonSerializerSettings jsonOptions =
            new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore };

        public WeatherClient(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public string BaseURL
        {
            get
            {
                var result = configuration.GetSection("MySettings").GetSection("weatherBaseUrl").Value;
                return result;
            }
        }
        
        public string appID
        {
            get
            {
                var result = configuration.GetSection("MySettings").GetSection("appID").Value;
                return result;
            }
        }
        public async Task<WeatherApiResponse> GetWeatherAsync(string q)
        {

            try
            {
                var finalResult = new WeatherApiResponse();
                var client = new HttpClient();
                client.BaseAddress = new Uri(BaseURL);
                var res = await client.GetAsync($"forecast?q={q}&appid={appID}");

                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    finalResult = JsonConvert.DeserializeObject<WeatherApiResponse>(results, jsonOptions);

                }             
                
                return finalResult;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
