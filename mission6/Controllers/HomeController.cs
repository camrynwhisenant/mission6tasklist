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
        public IActionResult TaskForm(Task at)
        {
            ViewBag.Categories = TaskContext.Categories.ToList();
            if (ModelState.IsValid)
            {
                TaskContext.Add(at);
                TaskContext.SaveChanges();

                return View("Index", at);
            }
            else
            {
                return View(at);
            }
        }


        [HttpGet]
        public IActionResult TaskList()
        {
            var task = TaskContext.Tasks
            .Include(x => x.Category)
            .OrderBy(x => x.Categoryid)
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
            TaskContext.Update(at);
            TaskContext.SaveChanges();
            return RedirectToAction("Index");
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
