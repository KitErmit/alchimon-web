using System;
using AlchemonWeb.Services.Loaders;

namespace AlchemonWeb.Services
{
	public interface IShopService
	{
		string Test();
	}

	public class SimpleShopService : IShopService
    {

		
		public SimpleShopService()
        {
        }

		public string Test()
        {
			AlchemonLoader loader = AlchemonLoader.getInstance();
			List<string> loadResponse = loader.Load();
			string response = string.Join("\n",loadResponse);
			return response;
        }
    }
}

