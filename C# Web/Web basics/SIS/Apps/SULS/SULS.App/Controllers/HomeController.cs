using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Services;
using SULS.App.ViewModels.Home;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private IProblemServices ProblemServices;
        public HomeController(IProblemServices services)
        {
            ProblemServices = services;
        }
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn()) return this.Redirect("/Home/IndexLoggedIn");
            return this.View();
        }
        [HttpGet("/Home/IndexLoggedIn")]
        public HttpResponse IndexLoggedIn()
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            var infoview = new LoggedInViewModel()
            {
                Problems = ProblemServices.GetAllProblems().Select(x => new ProblemInfo()
                {
                    Name = x.Name,
                    Count = x.Points,
                    Id = x.Id
                })
            };
            return this.View(infoview);
        }
    }
}