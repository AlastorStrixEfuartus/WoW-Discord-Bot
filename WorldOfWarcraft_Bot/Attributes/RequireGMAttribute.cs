using Discord.Commands;
using Discord.WebSocket;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft_Bot.Attributes
{
    public class RequireGMAttribute : PreconditionAttribute
    {
        public async override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            try
            {
                var user = services.GetService<DiscordSocketClient>().GetGuild(context.Guild.Id).GetUser(context.User.Id);
                if (user.Roles.Where(x => x.Id == (ulong)446238880539344937).Count() != 1)
                {
                    return PreconditionResult.FromError("You need to be a game master");
                }
                else
                    return PreconditionResult.FromSuccess();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
