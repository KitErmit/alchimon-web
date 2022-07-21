using System;
using AlchemonWeb.Services.Loaders;
using AlchemonWeb.AlPedia;
using AlchemonWeb.Models;

namespace AlchemonWeb.Services
{
	public interface IShopService
	{
		HashSet<Alchemon> Test();
		Alchemon BuyAnimal();
		string GetKarman();
		string GetHibrit(int leftAlNum, int rightAlNum);
	}

	public class SimpleShopService : IShopService
    {

		Dictionary<int,Alchemon> Karman = new();

		
		public SimpleShopService()
        {
        }

		public HashSet<Alchemon> Test()
        {
			
			return Bestiary.GetAlpedia();
        }

		public Alchemon BuyAnimal()
        {
			var newAl = AnimanlFactory.GetAlchemon();
			Karman.Add(Karman.Count +1 ,newAl);
			return newAl;
        }

		public string GetKarman()
        {
			string response = "";
			if (Karman.Count < 1) return "Пусто";
			foreach (var keyVal in Karman) response += $"{keyVal.Key}) {keyVal.Value.ToString()};\n";
            
			return response;
        }

		public string GetHibrit(int leftAlNum, int rightAlNum)
        {

			if (Karman[leftAlNum].Tear > 1 || Karman[rightAlNum].Tear > 1)
				return $"Гибрид не может быть сделан из гибрида";

			if (Karman.TryGetValue(leftAlNum, out Alchemon? left))
				Karman.Remove(leftAlNum);
			else return $"Животное под номером {leftAlNum} не найдено";
			if (Karman.TryGetValue(rightAlNum, out Alchemon? right))
				Karman.Remove(rightAlNum);
			else return $"Животное под номером {leftAlNum} не найдено";

			Alchemon hibrid = HibridFactory.GetHibrit(left, right);
			Karman.Add(Karman.Count + 1, hibrid);
			return hibrid.ToString();

		}

	}
}

