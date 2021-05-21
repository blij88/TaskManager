using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Data;

namespace TaskManager.App.Controllers
{
    public class HomeController : Controller
    {
        private TaskManagerDbContext db = new TaskManagerDbContext();
        private readonly ITaskData Db;
        public HomeController()
        {
            Db = new SqlTaskData(db);
        }

        public ActionResult Overview()
        {
            var model = Db.GetAll();

            foreach (var item in Db.GetAll())
            {
                Debug.WriteLine($"{item.Name}");
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            return View(model);
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
            return View();
        }
    }
}