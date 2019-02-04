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
    public class WebMessageData : IWebMessageData
    {
        private readonly ILogger<WebMessageData> _logger;
        public WebMessageData(ILogger<WebMessageData> logger)
        {
            _logger = logger;
        }

        public bool SendWebMessage(string url, object data)
        {
            try
            {
                HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(data);
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
