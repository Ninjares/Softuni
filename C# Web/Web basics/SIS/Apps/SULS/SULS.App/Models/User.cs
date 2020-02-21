using SIS.MvcFramework;
using System;

namespace SULS.App.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}