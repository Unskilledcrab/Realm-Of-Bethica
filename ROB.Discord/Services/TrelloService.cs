using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ROB.Discord.Secrets;
using ROB.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Discord.Services
{
    public class TrelloService
    {
        private readonly HttpClient _http;
        private readonly string BaseURI = "https://ubunlimited.com/api/trello";

        public TrelloService(HttpClient http)
            => _http = http;

        public class SuggestionUpdate
        {
            public int SuggestionId { get; set; }
            public SuggestionStatus StatusUpdate { get; set; }
        }

        public async Task<List<TrelloSuggestionModel>> GetSuggestionsAsync()
        {
            var resp = await _http.GetAsync(BaseURI);
            var output = await resp.Content.ReadAsStringAsync();

            return DownloadJsonData<List<TrelloSuggestionModel>>(output);
        }

        public async Task<List<TrelloSuggestionModel>> GetPendingSuggestions()
        {
            var resp = await _http.GetAsync(BaseURI + "/status/0");
            var output = await resp.Content.ReadAsStringAsync();

            return DownloadJsonData<List<TrelloSuggestionModel>>(output);
        }

        public async Task<TrelloSuggestionModel> GetSuggestionById(int id)
        {
            var resp = await _http.GetAsync(BaseURI + "/" + id);
            var output = await resp.Content.ReadAsStringAsync();

            return DownloadJsonData<TrelloSuggestionModel>(output);
        }

        public async Task<List<TrelloSuggestionModel>> GetSuggestionsByUserMention(string mention)
        {
            var resp = await _http.GetAsync(BaseURI + "/user/" + mention);
            var output = await resp.Content.ReadAsStringAsync();

            return DownloadJsonData<List<TrelloSuggestionModel>>(output);
        }

        public async Task<TrelloSuggestionModel> UpdateSuggestion(SuggestionUpdate suggestionUpdate)
        {
            var json = JsonConvert.SerializeObject(suggestionUpdate);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(BaseURI + "/update", data);
            string result = response.Content.ReadAsStringAsync().Result;
            
            return DownloadJsonData<TrelloSuggestionModel>(result);
        }

        public async Task<TrelloSuggestionModel> SendSuggestion(TrelloSuggestionModel suggestion)
        {
            var json = JsonConvert.SerializeObject(suggestion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(BaseURI, data);
            string result = response.Content.ReadAsStringAsync().Result;

            return DownloadJsonData<TrelloSuggestionModel>(result);
        }

        public static T DownloadJsonData<T>(string json_data) where T : new()
        {
            // if string with JSON data is not empty, deserialize it to class and return its instance 
            return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        }
    }
}
