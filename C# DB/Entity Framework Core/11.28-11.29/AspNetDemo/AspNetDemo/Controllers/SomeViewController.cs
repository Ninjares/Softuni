using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetDemo.Controllers
{
    public class SomeViewController : Controller
    {
        public IActionResult Index()
        {
            return View("SomeView");
        }
    }
}