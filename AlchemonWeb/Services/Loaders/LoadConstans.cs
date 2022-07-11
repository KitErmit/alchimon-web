using System;
namespace AlchemonWeb.Services.Loaders
{
	public static class LoadConstans
	{
		public static List<ILoader> Launch = new List<ILoader> { AlchemonLoader.getInstance()};

    }
}

