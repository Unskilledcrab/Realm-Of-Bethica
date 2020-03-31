using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ROB.Discord.Models.Secrets;
using ROB.Discord.Services;

namespace ROB.Discord
{
    public class Worker : BackgroundService
    {
        public static IServiceProvider Services;
        private readonly ILogger<Worker> _logger;
        private DiscordSocketClient _client;
        private IConfiguration _configuration { get; }

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var Services = ConfigureServices())
            {
                _client = Services.GetRequiredService<DiscordSocketClient>(); 

                _client.Log += LogAsync;
                Services.GetRequiredService<CommandService>().Log += LogAsync;

                // Setup globally used secrets
                _configuration.GetSection("UB").Get<DiscordSecrets>();
                _configuration.GetSection("Trello").Get<TrelloSecrets>();

                // Start up the bot
                await _client.LoginAsync(TokenType.Bot, _configuration["DiscordToken"]);
                await _client.StartAsync();

                await Services.GetRequiredService<CommandHandlingService>().InitializeAsync();
                
                // Block this task until the program is closed.
                await Task.Delay(-1);
            }
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<HttpClient>()
                .AddSingleton<PictureService>()
                .AddSingleton<TrelloService>()
                .BuildServiceProvider();
        }

        private Task LogAsync(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            _logger.LogDebug(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
