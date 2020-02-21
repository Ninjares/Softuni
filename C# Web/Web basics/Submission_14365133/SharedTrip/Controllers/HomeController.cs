namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    { 
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn()) return Redirect("/Trips/All");
            return this.View();
        }
    }
}