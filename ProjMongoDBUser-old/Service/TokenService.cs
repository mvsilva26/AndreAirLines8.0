﻿using Microsoft.IdentityModel.Tokens;
using Models.Model;
using ProjMongoDBUser.Properties;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjMongoDBUser.Service
{
    //public class TokenService
    //{

    //    public static string GenerateToken(User user)
    //    {
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var key = Encoding.ASCII.GetBytes(SettingsJWT.Secret);
    //        var acessApi = user.Function.Permission.Select(x => new Claim(ClaimTypes.Role, x.Description.ToString()));
    //        var tokenDescriptor = new SecurityTokenDescriptor
    //        {
    //            Subject = new ClaimsIdentity(acessApi),
    //            Expires = DateTime.UtcNow.AddHours(2),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //        };
    //        var token = tokenHandler.CreateToken(tokenDescriptor);
    //        return tokenHandler.WriteToken(token);
    //    }




    //}
}
