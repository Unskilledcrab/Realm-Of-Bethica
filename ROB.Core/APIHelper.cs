using System;
using System.Net;
using Newtonsoft.Json;

namespace ROB.Core
{
    /// <summary>
    /// DEPRECIATED.. This will be moving out of the core project
    /// </summary>
    public static class APIHelper
    {
        public static T DownloadJsonData<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
