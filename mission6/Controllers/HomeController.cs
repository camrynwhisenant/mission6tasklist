using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission6.Models;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TaskContext TaskContext { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            TaskContext = somename;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = TaskContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult TaskForm(AddTask at)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            if (ModelState.IsValid)
            {
            TaskContext.Add(am);
            TaskContext.SaveChanges();

            return View("Confirmation", at);
            }
            else
            {
                return View(at);
            }
        [HttpGet]
        public IActionResult TaskList()
        {
            var task = TaskContext.Tasks
            .Include(x => x.Category)
            .OrderBy(x => x.CategoryId)
            .ToList();
            return View(task);
        }
        [HttpGet]
        public IActionResult Edit (int TaskId)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            var category = TaskContext.Tasks.Single(x => x.TaskId == TaskId);
            return View("TaskForm", category);
        }
        [HttpPost]
        public IActionResult Edit (AddTask at)
        {
            TaskContext.Update(at);
            TaskContext.SaveChanges();
            return RedirectToAction("TaskList");
        }
        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var t = TaskContext.Tasks.Single(x => x.TaskId == TaskId);
            return View(t);
        }
        [HttpPost]
        public IActionResult Delete(AddTask at)
        {
            TaskContext.Tasks.Remove(at);
            TaskContext.SaveChanges();
            return RedirectToAction("TaskList");
        }

        }

    }
}
