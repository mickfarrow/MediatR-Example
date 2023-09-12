using EmployeeManagement.Api.Crypto;
using EmployeeManagement.Api.Entities;
using EmployeeManagement.Api.Helpers;
using EmployeeManagement.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Api.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = new User();

            var authUser = GetUser(username, password);

            // return null if user not found
            if (authUser == null)
                return null;

            user.Id = authUser.Id;
            user.Username = authUser.Username;
            user.FirstName = authUser.FirstName;
            user.LastName = authUser.LastName;

            var hashService = new HashService();

            var passwordHash = hashService.SaltAndHashPassword(password, authUser.PasswordSalt);

            if (passwordHash.Password != authUser.Password)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var expiry = DateTime.UtcNow.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim("Expiry", expiry.ToString())
                }),
                Expires = expiry,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
        private AuthUser GetUser(string username, string password)
        {
            DiveLoggerContext context = new DiveLoggerContext(_appSettings.ConnectionString);

            return context.AuthUser.SingleOrDefault(x => x.Username == username);
        }
    }
}