using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfWarcraft_Bot.Database;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using WorldOfWarcraft_Bot.Data;
using WorldOfWarcraft_Bot.Attributes;

namespace WorldOfWarcraft_Bot.Commands
{
    [Group("gm")]
    //[RequireGM]
    public class GMCommands : ModuleBase<SocketCommandContext>
    {
        #region Lookup
        [Command("creature")]
        public async Task CreatureLookup(string name)
        {
            var message = await Context.Channel.SendMessageAsync("Let me see... :thinking:");
            var creature = MySqlDatabaseHandler.GetCreature(name);
            if (creature == null)
            {
                return;
            }
            var eb = new EmbedBuilder();
            eb.WithTitle(creature.Name);
            eb.WithDescription("This is what I could find:");
            eb.AddField("Entry:", " " + creature.Entry, true);
            eb.AddField("Model ID:", " " + creature.ModelID1, true);
            eb.AddField("Min Level:", " " + creature.minLevel, true);
            eb.AddField("Max Level:", " " + creature.maxLevel, true);
            eb.AddField("AI Name:", " " + creature.AIName, true);
            eb.AddField("Script Name:", " " + creature.ScriptName, true);
            eb.WithTimestamp(DateTime.Now);
            eb.WithColor(Color.Red);
            await Context.Channel.SendMessageAsync("", false, eb.Build());
            await message.DeleteAsync();
            Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> Send Result : " + name);
        }
        #endregion
    }
}
