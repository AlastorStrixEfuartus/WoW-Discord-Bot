using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft_Bot.Data
{
    public class Character
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public Class Class { get; set; }
        public Gender Gender { get; set; }
        public int Level { get; set; }
    }

    public enum Class : int
    {
        Warrior = 1,
        Paladin = 2,
        Hunter = 3,
        Rogue = 4,
        Priest = 5,
        Death_Knight = 6,
        Shaman = 7,
        Mage = 8,
        Warlock = 9,
        Monk = 10,
        Druid = 11,
        Demon_Hunter = 12,
    }

    public enum Race : int
    {
        Human = 1,
        Orc = 2,
        Dwarf = 3,
        Night_Elf = 4,
        Undead = 5,
        Tauren = 6,
        Gnome = 7,
        Troll = 8,
        Goblin = 9,
        Blood_Elf = 10,
        Draenei = 11,
        Fel_Orc = 12,
        Naga = 13,
        Broken = 14,
        Skeleton = 15,
        Vrykul = 16,
        Tuskarr = 17,
        Forest_Troll = 18,
        Taunka = 19,
        Nothrend_Skeleton = 20,
        Ice_Troll = 21,
        Worgen = 22,
        Pandaren_Neutral = 23,
        Pandaren_Alliance = 24,
        Pandaren_Horde = 25
    }

    public enum Gender : int
    {
        Male = 0,
        Female = 1,
        Unknown = 2
    }

    public class CharacterStats
    {
        public int MaxHealth { get; set; }
        public int MaxPower1 { get; set; }
        public int MaxPower2 { get; set; }
        public int MaxPower3 { get; set; }
        public int MaxPower4 { get; set; }
        public int MaxPower5 { get; set; }
        public int MaxPower6 { get; set; }
        public int MaxPower7 { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Intellect { get; set; }
        public int Spirit { get; set; }
        public int Armor { get; set; }
    }
}