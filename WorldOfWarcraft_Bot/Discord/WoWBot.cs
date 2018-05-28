using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;


namespace WorldOfWarcraft_Bot.Discord
{
    public class WoWBot
    {
        internal static WoWBot Instance;
        internal static string BotName = "WoWBot";
        private CommandService _commands;
        private IServiceProvider _services;
        public DiscordSocketClient Bot;
        string token = "";

        public WoWBot()
        {
            Instance = this;
            Bot = new DiscordSocketClient();
        }

        public async Task Start()
        {
            _commands = new CommandService();
            await InstallCommandAsync();
            _services = new ServiceCollection().AddSingleton(Bot).AddSingleton(_commands).BuildServiceProvider();
            await Bot.LoginAsync(TokenType.Bot, token);
            await Bot.StartAsync();
            Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> Started Bot");
            Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> Bot Name : " + BotName);
            await Task.Delay(-1);
        }

        private Task Bot_Log(LogMessage arg)
        {
            Console.WriteLine("[" + DateTime.Now + "]" + arg.Message);
            return Task.CompletedTask;
        }

        public async Task InstallCommandAsync()
        {
            Bot.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        public async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null)
                return;
            int argPos = 0;
            if (!(message.HasCharPrefix('$', ref argPos) || message.HasMentionPrefix(Bot.CurrentUser, ref argPos)))
                return;
            var context = new SocketCommandContext(Bot, message);
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }

    }
}
