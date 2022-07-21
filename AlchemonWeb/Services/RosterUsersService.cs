using System;
using System.Text.Json;
using AlchemonWeb.Models;

namespace AlchemonWeb.Services
{
    public interface IRosterUsers
    {
        bool TryGetUser(string id, out Player found);
        bool TryPutUser(Player player);
        Dictionary<string, Player> GetRoster();
        void SaveRoster(Dictionary<string, Player> roster);
    }


    public class RosterUsersService : IRosterUsers
    {
        private const string _path = "Base/UserRoster.txt";

        public RosterUsersService()
        {

        }





        public bool TryGetUser(string id, out Player found)
        {
            
            return Load().TryGetValue(id, out found);
        }

        public bool TryPutUser(Player player)
        {
            var roster = Load();
            if (roster.ContainsKey(player.Id))
                return false;
            if (roster.ContainsValue(player))
                return false;
            roster.Add(player.Id, player);
            SaveRoster(roster);
            return true;
        }

        public Dictionary<string, Player> GetRoster()
        {
            var roster = string.Join
                (
                "\n\n",
                Load().Select(kv => kv.Value.ToString()).ToArray()
                );

            return Load();
        }

        public Dictionary<string, Player> Load ()
        {
            string json;
            using(StreamReader reader = new StreamReader(_path))
            {
                json = reader.ReadToEnd();
            }
            Dictionary<string, Player> roster = JsonSerializer.Deserialize<Dictionary<string, Player>>(json);
            return roster;
        }

        public void SaveRoster(Dictionary<string, Player> roster)
        {
            string json = JsonSerializer.Serialize(roster);
            using(StreamWriter writer = new StreamWriter(_path,false))
            {
                writer.Write(json);
            }
        }
    }


}

