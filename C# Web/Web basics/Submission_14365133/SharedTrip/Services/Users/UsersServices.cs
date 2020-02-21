using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services.Users
{
    public class UsersServices : IUsersServices
    {
        private readonly ApplicationDbContext db;
        public UsersServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = Hash(password),
                Email = email
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool EmailIsUsed(string email)
        {
            return db.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == Hash(password));
            if (user == null) return null;
            else return user.Id;
        }

        public bool UsernameExists(string username)
        {
            return db.Users.Any(x => x.Username == username);
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
