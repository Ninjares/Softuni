using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Services;
using SULS.App.ViewModels.Users;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private IUsersServices UsersServices { get; set; }
        public UsersController(IUsersServices services)
        {
            UsersServices = services;
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
            if (string.IsNullOrEmpty(userid)) return Redirect("Login");
            else
            {
                this.SignIn(userid);
                return Redirect("/Home/IndexLoggedIn");
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
            if(register.Username.Length<5 || register.Username.Length > 20)
            {
                return Redirect("Register");
            }
            if (register.Password != register.ConfirmPassword)
            {
                return Redirect("Register");
            }
            if (register.Password.Length < 6 || register.Password.Length > 20)
            {
                return Redirect("Register");
            }
            if(string.IsNullOrEmpty(register.Email))
            {
                return Redirect("Register");
            }
            if (UsersServices.EmailInUse(register.Email))
            {
                return Redirect("Register");
            }
            if (UsersServices.UsernameExists(register.Username))
            {
                return Redirect("Register");
            }
            UsersServices.Register(register.Username, register.Password, register.Email);
            return Redirect("Login");
        }
        [HttpGet("/Users/Logout")]
        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}