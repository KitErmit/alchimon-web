using System;
using AlchemonWeb.Models;
namespace AlchemonWeb.AlPedia
{
	public static class Bestiary
	{
		public static List<Alchemon> all;

		public static string Update(Alchemon downloadable)
        {
			if (all.Any(a => a.AlName == downloadable.AlName))
			{
				all.Add(downloadable);
				return $"{downloadable.AlName} загружен";
			}
			else return $"{downloadable.AlName} уже есть";
				
        }
		
	}
}

