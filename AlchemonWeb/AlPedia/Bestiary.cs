using System;
using AlchemonWeb.Models;
using AlchemonWeb.Services;
using AlchemonWeb.Services.Loaders;

namespace AlchemonWeb.AlPedia
{
	public static class Bestiary
	{
		private static readonly HashSet<Alchemon> all = new();

		public static string Update(Alchemon downloadable)
        {
			if (!all.Add(downloadable))
			{
				return $"{downloadable.AlName} уже есть";
			}

			return $"{downloadable.AlName} загружен";
        }

		public static HashSet<Alchemon> GetAlpedia()
        {
			if(all.Count <1)
            {
				AbsoluteLoader loader = AbsoluteLoader.getInstance();
				loader.PutInQueue(LoadConstans.Launch);
				loader.Load();
            }
			return all;
        }

	}
}

