using System;
using System.IO;
using AlchemonWeb.AlPedia;
using AlchemonWeb.Models;

namespace AlchemonWeb.Services.Loaders
{
	public class AlchemonLoader : ILoader
	{
		private const string path = "./AlPedia/AlList.txt";
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
	        List<string> response = new List<string> { "ЗАГРУЗКА Бестиария:\n" };

	        foreach (var text in File.ReadLines(path))
			{
				if (text.StartsWith("АлИмя")) continue;
				string[] position = text.Split(',');
				string alname = position[0];
				string em = position[1];
				int hp = Convert.ToInt32(position[2]);
				int dm = Convert.ToInt32(position[3]);
				int agi = Convert.ToInt32(position[4]);
				string noise = position[5];

				string line = Bestiary.Update(new Alchemon(alname, em, hp, dm, agi, noise));
				response.Add(line);
			}
            
            return response;
        }

    }
}

