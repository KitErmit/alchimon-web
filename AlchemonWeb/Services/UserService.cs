using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

using AlchemonWeb.Models;

namespace AlchemonWeb.Services
{
    public interface IUserService
    {
        string Registration(string nik, string password, bool role);
        string Autification(string nik, string password);
        string GetRoster();
    }

    public class SimpleUserService : IUserService
    {
        private readonly IRosterUsers _roster;

        public SimpleUserService(IRosterUsers roster)
        {
            _roster = roster;
        }

        public string Registration(string nik, string password, bool role)
        {
            string roleStr;
            int money;
            if (role) { roleStr = RoleConsts.God; money = 1_000_000; }
            else { roleStr = RoleConsts.Player; money = 100; }

            Player newPlayer = new Player(nik, password, roleStr, money);
            if (_roster.TryPutUser(newPlayer))
                return $"Поздравляю, {newPlayer.Nik}. Ваш Айди {newPlayer.Id}";
            else return $"Ошибка создания айди или идентичный юзер есть в реестре";

        }

        public string Autification(string nik, string password)
        {
            Player? player = _roster.GetRoster().Select(kp => kp.Value).FirstOrDefault(p => p.Nik.ToLower() == nik.ToLower() && p.Password == password);
            if (player is null) return "Не верный логин или пароль";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, player.Nik),
                new Claim(ClaimTypes.Role, player.role),
                new Claim(ClaimTypes.Country, player.Id)
            };
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(15)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return $"{player.Nik}\n{encodedJwt}";
        }

        public string GetRoster()
        {
            return string.Join
                (
                "\n\n",
                _roster.GetRoster().Select(kv => kv.Value.ToString()).ToArray()
                );
        }

    }
}

