using System;
using AlchemonWeb.Models;
namespace AlchemonWeb.AlPedia
{
    public static class HibridFactory
    {
        public static Alchemon GetHibrit(Alchemon left, Alchemon right)
        {
            string AlName = "";
            if ((left.AlName == "паук" && right.AlName == "свин") || (left.AlName == "свин" && right.AlName == "паук"))
                AlName = "свин-паук";
            else AlName = left.AlName + "о" + right.AlName;
            string Emoji = left.Emoji + right.Emoji;
            int Hp = left.Hp + right.Hp;
            int DMG = left.Dmg + right.Dmg;
            int Agi = left.Agi + right.Agi;
            string Noise = left.Noise;



            Alchemon hibrid = new Alchemon(AlName, Emoji, Hp, DMG, Agi, Noise);
            hibrid.Tear++;
            return hibrid;
        }
    }
}

