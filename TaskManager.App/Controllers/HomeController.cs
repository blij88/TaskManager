using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.App.ViewModels;
using TaskManager.Data;
using TaskManager.Data.models;

namespace TaskManager.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskDataRepository Db;
        public HomeController()
        {
            Db = new TaskDataRepository();
        }

        public ActionResult Overview()
        {
            List<Task> task = Db.GetAll();
            var model = new OverviewViewModel(task);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Task task = Db.Get(id);
            Db.Delete(task);
            return RedirectToAction("Overview");
        }

        public ActionResult Edit(int id)
        {
            var model = Db.Get(id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if(ModelState.IsValid)
            {
                Db.Update(task);
                return RedirectToAction("Details", new { id = task.Id });
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
            Db.Add(task);
            return RedirectToAction("Overview");
            }
            return View(task);
        }
    }
}