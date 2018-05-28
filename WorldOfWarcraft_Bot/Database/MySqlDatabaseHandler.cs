using Discord;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfWarcraft_Bot.Data;

namespace WorldOfWarcraft_Bot.Database
{
    class MySqlDatabaseHandler
    {
        private static readonly string CharConnString = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=tc_char;";
        private static readonly string WorldConnString = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=tc_world;";
        private static readonly string AuthConnString = "SERVER=localhost;UID=root;PASSWORD=;DATABASE=tc_auth;";

        #region Character
        public static Character GetCharacter(string name)
        {
            var c = new Character();
            var query = "SELECT * FROM characters WHERE name=@name limit 1";
            try
            {
                using (var CONN = new MySqlConnection(CharConnString))
                {
                    CONN.Open();
                    using (var COMMAND = new MySqlCommand(query, CONN))
                    {
                        COMMAND.Parameters.Add(new MySqlParameter("@name", name));
                        using (var READER = COMMAND.ExecuteReader())
                        {
                            while (READER.Read())
                            {
                                c.Name = Convert.ToString(READER["name"]);
                                c.Race = (Race)Convert.ToInt32(READER["race"]);
                                c.Class = (Class)Convert.ToInt32(READER["class"]);
                                c.Gender = (Gender)Convert.ToInt32(READER["gender"]);
                                c.Level = Convert.ToInt32(READER["level"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> " + ex.Message);
            }
            return c;
        }
        public static CharacterStats GetCharStats(string name)
        {
            var c = new CharacterStats();
            var query = "SELECT cs.* FROM character_stats cs INNER JOIN characters ct ON cs.guid = ct.guid WHERE ct.name = @name";
            try
            {
                using (var conn = new MySqlConnection(CharConnString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.Add(new MySqlParameter("@name", name));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                c.MaxHealth = Convert.ToInt32(reader["maxhealth"]);
                                c.MaxPower1 = Convert.ToInt32(reader["maxpower1"]);
                                c.MaxPower2 = Convert.ToInt32(reader["maxpower2"]);
                                c.MaxPower3 = Convert.ToInt32(reader["maxpower3"]);
                                c.MaxPower4 = Convert.ToInt32(reader["maxpower4"]);
                                c.MaxPower5 = Convert.ToInt32(reader["maxpower5"]);
                                c.MaxPower6 = Convert.ToInt32(reader["maxpower6"]);
                                c.MaxPower7 = Convert.ToInt32(reader["maxpower7"]);
                                c.Strength = Convert.ToInt32(reader["strength"]);
                                c.Agility = Convert.ToInt32(reader["agility"]);
                                c.Stamina = Convert.ToInt32(reader["stamina"]);
                                c.Intellect = Convert.ToInt32(reader["intellect"]);
                                c.Spirit = Convert.ToInt32(reader["spirit"]);
                                c.Armor = Convert.ToInt32(reader["armor"]);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> " + ex.Message);
            }

            return c;
        }
        #endregion
        #region World
        public static Creature GetCreature(string name)
        {
            var c = new Creature();
            var query = "SELECT * FROM creature_template WHERE name = @name";
            try
            {
                using (var conn = new MySqlConnection(WorldConnString))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.Add(new MySqlParameter("@name", name));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                c.Entry = Convert.ToInt32(reader["entry"]);
                                c.ModelID1 = Convert.ToInt32(reader["modelid1"]);
                                c.Name = Convert.ToString(reader["name"]);
                                c.minLevel = Convert.ToInt32(reader["minlevel"]);
                                c.maxLevel = Convert.ToInt32(reader["maxlevel"]);
                                c.AIName = Convert.ToString(reader["AIName"]);
                                c.ScriptName = Convert.ToString(reader["ScriptName"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[" + DateTime.Now + "]" + "[BOT] -> " + ex.Message);
            }

            return c;
        }
        #endregion
        #region Auth
            
        #endregion
    }
}
