namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Employees;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using FastFood.Models;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            var positions = context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider).ToList();
            return View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!this.ModelState.IsValid)
                return View("Error", "Home");
            var employee = mapper.Map<Employee>(model);
            context.Employees.Add(employee);
            context.SaveChanges();
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var employees = context.Employees.ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider).ToList();
            return View("All", employees);
        }
    }
}
