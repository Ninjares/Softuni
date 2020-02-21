using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Services;
using SULS.App.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private IProblemServices ProblemServices { get; set; }
        public ProblemsController(IProblemServices services)
        {
            ProblemServices = services;
        }
        [HttpGet("/Problems/Create")]
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            return this.View();
        }
        [HttpPost("/Problems/Create")]
        public HttpResponse Create(ProblemCreateModel problemModel)
        {
            if (problemModel.Name.Length < 5 || problemModel.Name.Length > 20)
            {
                return Redirect("/Problems/Create");
            }
            if (problemModel.Points<50||problemModel.Points>300)
            {
                return Redirect("/Problems/Create");
            }
            if (ProblemServices.NameUsed(problemModel.Name))
            {
                return Redirect("/Problems/Create");
            }
            ProblemServices.Create(problemModel.Name, problemModel.Points);
            return Redirect("/Home/IndexLoggedIn");
        }
        [HttpGet]
        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            if (!ProblemServices.ProblemExists(id)) return Redirect("/");
            var data = new ProblemDetails()
            {
                Submissions = ProblemServices.GetSubmissionsFor(id),
                MaxPoints = ProblemServices.MaxPointsFor(id),
                Name = ProblemServices.GetNameFor(id),
                ProblemId = id
            };
            return this.View(data);
        }
    }
}
