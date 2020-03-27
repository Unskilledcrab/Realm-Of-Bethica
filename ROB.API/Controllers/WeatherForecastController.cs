using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ROB.Discord.API;
using ROB.Discord.Services;

namespace ROB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public TrelloService TrelloService { get; set; }

        [HttpGet("embed")]
        public string Embed()
        {
            var embed = new EmbedBuilder()
                .WithTitle("Test Title")
                .WithDescription("Test Description")
                .AddField("Trello Board", "Click [here](https://trello.com/developers78278598) to go to trello home")
                .WithFooter(footer => footer.Text = "UB Unlimited")
                .WithCurrentTimestamp()
                .Build();

            TrelloService.SendUBAnnouncement(embed);

            return "Success";
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }        
    }
}
