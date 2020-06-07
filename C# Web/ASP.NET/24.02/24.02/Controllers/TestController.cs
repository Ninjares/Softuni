using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _24._02.Controllers
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    public class TestInputModel
    {
        public int Id { get; set; }
        [Display(Name = "Nibba's name is:")] //Display name for forms <label asp=fpr=""/>
        [StringLength(20, MinimumLength = 5)] // <span asp-validation-for=""/>
        public string Name { get; set; }
        public int[] Years { get; set; }
        public Person Person { get; set; }
        //[DataType(DateTime.Date)]
        public DateTime DateTime { get; set; }
        public CandidateType CandidateType { get; set; }
        public bool IsValid()
        {
            return true;
        }
    }

    public enum CandidateType //<select asp-for="" class="form-control" asp-items="">
    {
        cok = 1,
        bumpa = 2
    }
    public class TestController : Controller
    {
        [HttpGet("Test")]
        //Test?id=1&name=yey&years[0]=2&years[1]=999&Person.Firstname=tashi
        public IActionResult Test(/*[BindNever]*/TestInputModel model) //WTF are binders
        {
            if(model.IsValid() == false) //model.ModelState
            {
                return this.Content("Invalid Model");
            }
            return this.Json(model);
        }
    }
}
