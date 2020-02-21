using SharedTrip.Services.Users;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private IUsersServices UsersServices { get; set; }
        public UsersController(IUsersServices services)
        {
            this.UsersServices = services;
        }
        [HttpGet("/Users/Login")]
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn()) return Redirect("/");
            return this.View();
        }
        [HttpPost("/Users/Login")]
        public HttpResponse Login(LoginModel login)
        {
            var userid = UsersServices.GetUserId(login.Username, login.Password);
            if (String.IsNullOrEmpty(userid))
            {
                return Redirect("/Users/Login");
            }
            else
            {
                this.SignIn(userid);
                return Redirect("/");
            }
        }

        [HttpGet("/Users/Register")]
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn()) return Redirect("/");
            return this.View();
        }
        [HttpPost("/Users/Register")]
        public HttpResponse Register(RegisterModel register)
        {
            if (register.Username.Length < 5 || register.Username.Length > 20 || UsersServices.UsernameExists(register.Username))
            {
                return Redirect("/Users/Register");
            }
            if (register.Password.Length < 6 || register.Password.Length > 20 || register.Password != register.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }
            if (String.IsNullOrEmpty(register.Email) || UsersServices.EmailIsUsed(register.Email))
            {
                return Redirect("/Users/Register");
            }
            UsersServices.Create(register.Username, register.Password, register.Email);
            return Redirect("/Users/Login");
        }
        [HttpGet("/Users/Logout")]
        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
