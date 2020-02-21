using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Services
{
    public interface IUsersServices
    {
        void Register(string name, string password, string email);
        string GetUserId(string name, string password);
        bool UsernameExists(string name);
        bool EmailInUse(string email);
    }
}
