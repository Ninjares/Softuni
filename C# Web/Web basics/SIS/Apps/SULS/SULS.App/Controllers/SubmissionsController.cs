using SIS.HTTP;
using SIS.MvcFramework;
using SULS.App.Models;
using SULS.App.Services;
using SULS.App.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private ISubmissonServices SubmissonServices { get; set; }
        public SubmissionsController(ISubmissonServices services)
        {
            SubmissonServices = services;
        }
        [HttpGet]
        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            if (!SubmissonServices.ProblemExists(id)) return Redirect("/");
            var viewModel = new CreateViewModel()
            {
                ProblemId = id,
                Name = SubmissonServices.GetProblemName(id)
            };
            return this.View(viewModel);
        }
        [HttpPost]
        public HttpResponse Create(SubmissionData data)
        {
            if (data.Code.Length < 30|| data.Code.Length > 800) return Redirect("/Submissions/Create?id="+data.ProblemId);
            SubmissonServices.Create(data.ProblemId, User, data.Code);
            return Redirect("/");
        }
        [HttpGet("/Submissions/Delete")]
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn()) return Redirect("/");
            if (!SubmissonServices.SubmissionExists(id)) return Redirect("/");
            var problemid = SubmissonServices.GetProblemId(id);
            SubmissonServices.Delete(id);
            return Redirect("/Problems/Details?id="+problemid);
        }
    }
}
