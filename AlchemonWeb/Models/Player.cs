using System;
namespace AlchemonWeb.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Nik { get; set; }
        public string Password { get; set; }
        public  string role { get; set; }
        public int Money { get; set; }
        public List<Alchemon> Karman { get; set; }


        public Player(string nik, string password, string role, int money)
        {
            Id = Guid.NewGuid().ToString();
            Nik = nik;
            Password = password;
            this.role = role;
            Money = money;
            Karman = new List<Alchemon>();
        }



        public override string ToString()
        {
            return $"Id: {Id}\nNik: {Nik}\nPass: {Password}\nRole: {role}\nMoney: {Money}\nKarman.Count {Karman.Count}";
        }

    }

    public static class RoleConsts
    {
        public const string Player = "player";
        public const string God = "god";
    }



}

