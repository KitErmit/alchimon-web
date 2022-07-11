using System;
using System.IO;
using AlchemonWeb.AlPedia;
using AlchemonWeb.Models;

namespace AlchemonWeb.Services.Loaders
{
	public class AlchemonLoader : ILoader
	{
		private const string path = "/Users/kitaermit/Projects/AlchemonWeb/AlchemonWeb/AlPedia/AlList.txt";
		private static AlchemonLoader instance;
        private AlchemonLoader()
		{
		}
		public static AlchemonLoader getInstance()
        {
			if (instance is null) instance = new AlchemonLoader();
			return instance;
        }

		public List<string> Load()
        {
            List<string> loadable = new List<string>();
            List<string> response = new List<string> { "ЗАГРУЗКА Бестиария:\n" };
            string? text;
			using (StreamReader reader = new StreamReader(path))
            {
                while ((text = reader.ReadLine()) != null)
                {
                    if (text.StartsWith("АлИмя")) continue;
                    loadable.Add(text);
                }

                foreach (string bes in loadable)
                {
                    string[] position = bes.Split(',');
                    string alname = position[0];
                    string em = position[1];
                    int hp = Convert.ToInt32(position[2]);
                    int dm = Convert.ToInt32(position[3]);
                    int agi = Convert.ToInt32(position[4]);
                    string noise = position[5];

                    string line = Bestiary.Update(new Alchemon(alname, em, hp, dm, agi, noise));
                    response.Add(line);
                }
                
            }
            
            return response;
        }

    }
}

