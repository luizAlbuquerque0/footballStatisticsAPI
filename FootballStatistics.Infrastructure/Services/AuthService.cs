﻿using FootballStatistics.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace FootballStatistics.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configurations;
        public AuthService(IConfiguration configuration)
        {
            _configurations = configuration;
        }
        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));


                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
