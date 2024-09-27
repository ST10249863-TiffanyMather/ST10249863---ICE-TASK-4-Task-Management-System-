using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICE_TASK_4___Task_Management_System.Models;

namespace ICE_TASK_4_Task_Management_System.Controllers
{
    public class TaskController : Controller
    {
        // In-memory list to store tasks
        private static List<TaskModel> tasks = new List<TaskModel>();

        // GET: Task
        public IActionResult Index()
        {
            return View(tasks);
        }

        // GET: Task/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = tasks.FirstOrDefault(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Deadline")] TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                // Assign a new unique ID to the task
                taskModel.Id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
                tasks.Add(taskModel);
                return RedirectToAction(nameof(Index));
            }
            return View(taskModel);
        }

        // GET: Task/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = tasks.FirstOrDefault(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }
            return View(taskModel);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,Deadline")] TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTask = tasks.FirstOrDefault(t => t.Id == id);
                if (existingTask != null)
                {
                    existingTask.Title = taskModel.Title;
                    existingTask.Description = taskModel.Description;
                    existingTask.Deadline = taskModel.Deadline;
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(taskModel);
        }

        // GET: Task/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskModel = tasks.FirstOrDefault(m => m.Id == id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return View(taskModel);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var taskModel = tasks.FirstOrDefault(t => t.Id == id);
            if (taskModel != null)
            {
                tasks.Remove(taskModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
