using KnightArcade.Infrastructure.Data.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KnightArcade.Infrastructure.Data
{
    public class AutomatedTestingData : IAutomatedTestingData
    {
        private readonly ILogger<AutomatedTestingData> _logger;

        public AutomatedTestingData(ILogger<AutomatedTestingData> logger)
        {
            _logger = logger;
        }


        //TODO: Add config to game object file.
        public bool PostGameForTesting(string url, object game, object config)
        {
            try
            {
                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(game);
                client.PostAsJsonAsync(url, json);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return false;
            }
        }
    }
}
