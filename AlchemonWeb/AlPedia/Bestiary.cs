using System;
using AlchemonWeb.Models;
namespace AlchemonWeb.AlPedia
{
	public static class Bestiary
	{
		public static readonly HashSet<Alchemon> all = new();

		public static string Update(Alchemon downloadable)
        {
			if (!all.Add(downloadable))
			{
				return $"{downloadable.AlName} уже есть";
			}

			return $"{downloadable.AlName} загружен";
        }
		
	}
}

