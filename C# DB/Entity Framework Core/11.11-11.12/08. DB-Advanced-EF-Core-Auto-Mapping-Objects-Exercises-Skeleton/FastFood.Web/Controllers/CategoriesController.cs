namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using Data;
    using ViewModels.Categories;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Collections.Generic;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Hybrid()
        {
            IList<CategoryAllViewModel> categories = context.Categories.ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider).ToList();
            return this.View("Hybrid", categories);
        }
        [HttpPost]
        public IActionResult HybridCreate(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", "Home");
            }
            var category = this.mapper.Map<Category>(model);
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Hybrid", "Categories");
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", "Home");
            }
            var category = this.mapper.Map<Category>(model);
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            IList<CategoryAllViewModel> categories = context.Categories.ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider).ToList();
            return View("All", categories);
        }
    }
}
