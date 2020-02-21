using SULS.App.Models;
using SULS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SULS.App.Services
{
    public class UserServices : IUsersServices
    {
        private readonly SULSContext db;
        public UserServices(SULSContext db)
        {
            this.db = db;
        }
        public bool EmailInUse(string email)
        {
            return db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string name, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == name && x.Password == Hash(password));
            if (user == null) return null;
            else return user.Id;
        }

        public bool UsernameExists(string name)
        {
            return db.Users.Any(x => x.Username == name);
        }

        public void Register(string name, string password, string email)
        {
            var user = new User()
            {
                Username = name,
                Password = Hash(password),
                Email = email
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
                return null;

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
