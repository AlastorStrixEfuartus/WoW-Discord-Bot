using System;
using WorldOfWarcraft_Bot.Discord;

namespace WorldOfWarcraft_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            new WoWBot().Start();
            Console.ReadLine();
        }
    }
}
