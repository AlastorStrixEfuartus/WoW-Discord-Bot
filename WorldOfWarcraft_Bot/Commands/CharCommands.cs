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

namespace WorldOfWarcraft_Bot.Commands
{
    public class CharCommands : ModuleBase<SocketCommandContext>
    {
        #region Character Commands
        [Command("char")]
        public async Task CharAsync(string name)
        {
            var message = await Context.Channel.SendMessageAsync("Let me see... :thinking:");
            var character = MySqlDatabaseHandler.GetCharacter(name);
            if (character == null)
            {
                return;
            }
            var eb = new EmbedBuilder();
            eb.WithDescription("This is what I could find:");
            eb.AddField("Race:", " " + Convert.ToString(character.Race).Replace('_', ' '), true);
            eb.AddField("Class:", " " + Convert.ToString(character.Class).Replace('_', ' '), true);
            eb.AddField("Gender:", " " + Convert.ToString(character.Gender), true);
            eb.AddField("Level:", " " + character.Level, true);
            switch (character.Class)
            {
                case Class.Warrior:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/e/ee/Warrior_crest.png/revision/latest?cb=20130813095500");
                    break;
                case Class.Paladin:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/e/ee/Warrior_crest.png/revision/latest?cb=20130813095500");
                    break;
                case Class.Hunter:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/2/20/Hunter_crest.png/revision/latest?cb=20130813094921");
                    break;
                case Class.Rogue:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/e/e2/Rogue_crest.png/revision/latest?cb=20130813095139");
                    break;
                case Class.Priest:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/7/71/Priest_crest.png/revision/latest?cb=20130813095106");
                    break;
                case Class.Death_Knight:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/3/30/Death_knight_crest.png/revision/latest?cb=20130813094520");
                    break;
                case Class.Shaman:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/d/df/Shaman_crest.png/revision/latest?cb=20130813095240");
                    break;
                case Class.Mage:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/b/b8/Mage_crest.png/revision/latest?cb=20130813094952");
                    break;
                case Class.Warlock:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/4/4f/Warlock_crest.png/revision/latest?cb=20130813095321");
                    break;
                case Class.Monk:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/6/60/Monk_crest.png/revision/latest?cb=20130817144820");
                    break;
                case Class.Druid:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/5/55/Druid_crest.png/revision/latest?cb=20130813094831");
                    break;
                case Class.Demon_Hunter:
                    eb.WithThumbnailUrl("https://vignette.wikia.nocookie.net/wowwiki/images/d/db/Demon_hunter_crest-250x271.png/revision/latest?cb=20151004044357");
                    break;
            }
            eb.WithTimestamp(DateTime.Now);
            eb.WithAuthor(author =>
            {
                author
                .WithName(character.Name);
            });
            eb.WithColor(Color.Red);
            await Context.Channel.SendMessageAsync("", false, eb.Build());
            await message.DeleteAsync();
            Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> Send Character : " + name);
        }

        [Command("charstat")]
        public async Task CharStatAsync(string name)
        {
            var message = await Context.Channel.SendMessageAsync("Let me see... :thinking:");
            var character = MySqlDatabaseHandler.GetCharStats(name);
            if (character == null)
            {
                return;
            }
            var eb = new EmbedBuilder();
            eb.WithTitle("Character Stats");
            eb.WithDescription("This is what I could find:");
            eb.AddField("Max Health:", " " + character.MaxHealth, true);
            eb.AddField("Mana:", " " + character.MaxPower1, true);
            eb.AddField("Rage:", " " + character.MaxPower2, true);
            eb.AddField("Focus:", " " + character.MaxPower3, true);
            eb.AddField("Energy:", " " + character.MaxPower4, true);
            eb.AddField("Happiness:", " " + character.MaxPower5, true);
            eb.AddField("Rune:", " " + character.MaxPower6, true);
            eb.AddField("Runic Power:", " " + character.MaxPower7, true);
            eb.AddField("Strength:", " " + character.Strength, true);
            eb.AddField("Agility:", " " + character.Agility, true);
            eb.AddField("Stamina:", " " + character.Stamina, true);
            eb.AddField("Intellect:", " " + character.Intellect, true);
            eb.AddField("Spirit:", " " + character.Spirit, true);
            eb.AddField("Armor:", " " + character.Armor, true);
            eb.WithTimestamp(DateTime.Now);
            eb.WithColor(Color.Red);
            await Context.Channel.SendMessageAsync("", false, eb.Build());

            await message.DeleteAsync();
            Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> Send Character Stats : " + name);
        }
        #endregion
    }
}
