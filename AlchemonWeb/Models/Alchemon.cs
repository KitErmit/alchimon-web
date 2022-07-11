using System;
namespace AlchemonWeb.Models
{
	public class Alchemon : ICloneable
    {
        public string Name { get; set; }
        public string AlName { get; set; }
        public string Emoji { get; set; }
        //public Spacial spacial { get; set; }
        public int _hp { get; set; }
        public int _dmg { get; set; }
        public int _agi { get; set; }

        public int _tear { get; set; }
        public int _maxpoint { get; set; }
        public string _noise { get; set; }



        public Alchemon(string alName, string Emoji, int hp, int dmg, int agi, string noise)
        {
            AlName = alName;
            this.Emoji = Emoji;
            _hp = hp;
            _dmg = dmg;
            _agi = agi;
            _tear = 1;
            Name = "None";
            _noise = noise;
            _maxpoint = 70;
        }


        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return base.ToString() + $": ";
        }
    }
}

