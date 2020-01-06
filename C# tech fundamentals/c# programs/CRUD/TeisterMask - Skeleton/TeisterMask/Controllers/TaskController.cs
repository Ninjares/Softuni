using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeisterMask.Data;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new TeisterMaskDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status)){
                return RedirectToAction("Index");
            }


            Task newtask = new Task();
            {
                newtask.Title = title;
                newtask.Status = status;
            }
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(newtask);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null) return RedirectToAction("Index");

                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.Find(task.Id);
                taskToEdit.Status = task.Status;
                taskToEdit.Title = task.Title;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDelete == null) return RedirectToAction("Index");

                return this.View(taskToDelete);
            }

        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {

            using (var db = new TeisterMaskDbContext())
            {
                var tasktodelete = db.Tasks.FirstOrDefault(t => t.Id == task.Id);
                
                if (tasktodelete == null)
                  {
                      RedirectToAction("Index");
                  }
                db.Tasks.Remove(tasktodelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }











    }
}
