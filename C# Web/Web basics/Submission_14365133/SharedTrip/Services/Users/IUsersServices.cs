using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Users
{
    public interface IUsersServices
    {
        void Create(string username, string password, string email);
        bool UsernameExists(string username);
        bool EmailIsUsed(string email);
        string GetUserId(string username, string password);
    }
}
