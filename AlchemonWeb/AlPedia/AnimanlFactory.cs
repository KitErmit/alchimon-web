using System;
using AlchemonWeb.Models;
namespace AlchemonWeb.AlPedia
{
    public static class AnimanlFactory
    {
        public static Alchemon GetAlchemon()
        {
            Alchemon[] alchemons = new Alchemon[Bestiary.GetAlpedia().Count];
            Bestiary.GetAlpedia().CopyTo(alchemons);
            Random rnd = new Random();
            int indexRandomAl = rnd.Next(alchemons.Length);
            return alchemons[indexRandomAl];
        }
    }
}

