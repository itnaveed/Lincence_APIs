using Database;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static Common.Constants;


namespace Common
{
    public class JwtHelper
    {
        public static string CreateToken(User us)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", us.Id.ToString()),
                new Claim("Email", us.Email),
                new Claim("FirstName", us.FirstName),
                new Claim("LastName", us.LastName),
                new Claim("LoginTime", DateTime.Now.ToString())
                //new Claim("Role", user.RoleId.ToString())
            };

            //var configKey = AppSettingsHelper.GetAttributeValue(AppSettings.JWT_SECTION, AppSettings.JWT_KEY);
            var configKey = AppSettingsHelper.GetAttributAppSettings(AppSettings.JWT_SECTION, AppSettings.JWT_KEY);
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configKey));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(issuer: AppSettingsHelper.GetAttributAppSettings(AppSettings.JWT_SECTION, AppSettings.JWT_ISSUER),
                                                audience: AppSettingsHelper.GetAttributAppSettings(AppSettings.JWT_SECTION, AppSettings.JWT_AUDIENCE),
                                                signingCredentials: credentials,
                                                expires: DateTime.Now.AddMinutes(1),
                                                claims: claims);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
           
        }
        public static dynamic DecodeJWT(string accessToken)
        {
            var jwtEncodedString = accessToken.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            return token;
           
        }
    }
}
