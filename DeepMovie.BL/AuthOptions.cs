using DeepMovie.Common.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DeepMovie.BL
{
    public class AuthOptions
    {
        private readonly static IConfiguration _configuration;
        private readonly static string _tokenKey;
        static AuthOptions()
        {
            JObject data = JObject.Parse(File.ReadAllText("./appsettings.json"));
            _tokenKey = data["tokenKey"].ToString();
        }
        public const string ISSUER = "https://localhost"; // издатель токена
        public const string AUDIENCE = "https://localhost"; // потребитель токена
        public const int LIFETIME = 1000; // время жизни токена - 1000 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenKey));
        }
        ClaimsIdentity GetClaims(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("login", user.Login),
                    new Claim("role", user.Role.ToString())
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
        public string GetToken(User user)
        {
            var claims = GetClaims(user);
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(

                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    //данные юзера
                    claims: claims.Claims,
                    //время жизни токена
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)

               );
            //кодирование токена
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }


        public int GetIdFromToken(string token)
        {
            //создание handler
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            return int.Parse(jwt.Claims.First(x => x.Type == "id").Value);
        }
    }
}
