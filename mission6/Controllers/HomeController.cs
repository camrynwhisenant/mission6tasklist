using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission6.Models;
using Task = mission6.Models.Task;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext TaskContext { get; set; }

        public HomeController(TaskContext someName)
        { 
            TaskContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(Task at)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            if (ModelState.IsValid)
            {
                TaskContext.Add(at);
                TaskContext.SaveChanges();

                return RedirectToAction("TaskList");
            }
            else
            {
                ViewBag.categories = TaskContext.Categories.ToList();
                return View(at);
            }
        }

        [HttpGet]
        public IActionResult TaskList()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            var task = TaskContext.Tasks
            .Include(x => x.Category)
            .OrderBy(x => x.Categoryid)
            .Where(x => x.Completed == false)
            .ToList();
        
            return View(task);
        }

        [HttpGet]
        public IActionResult Edit (int TaskId)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            var category = TaskContext.Tasks.Single(x => x.TaskID == TaskId);
            return View("TaskForm", category);
        }

        [HttpPost]
        public IActionResult Edit (Task at)
        {

            if (ModelState.IsValid)
            {
                TaskContext.Update(at);
                TaskContext.SaveChanges();

                return RedirectToAction("TaskList");
            }
            else
            {
                ViewBag.categories = TaskContext.Categories.ToList();
                return View(at);
            }
        }

        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var t = TaskContext.Tasks.Single(x => x.TaskID == TaskId);
            return View(t);
        }

        [HttpPost]
        public IActionResult Delete(Task at)
        {
            TaskContext.Tasks.Remove(at);
            TaskContext.SaveChanges();
            return RedirectToAction("TaskList");
        }
    }
}
