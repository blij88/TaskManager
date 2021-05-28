using System.Collections.Generic;
using System.Web.Mvc;
using TaskManager.App.ViewModels;
using TaskManager.Data;
using TaskManager.Data.models;

namespace TaskManager.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskData Db;
        public HomeController()
        {
            Db = new TaskDataRepository();
        }

        public ActionResult Overview()
        {
            List<Task> task = Db.GetAll();
            var model = new OverviewViewModel(task);

            model.Contacts = Db.GetAllContacts();

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
            if (ModelState.IsValid)
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

        public ActionResult DetailsContact(int id)
        {
            var model = Db.GetContact(id);
            return View(model);
        }

        public ActionResult DeleteContact(int id)
        {
            PeopleWhoCanHelp peopleWhoCanHelp = Db.GetContact(id);
            Db.DeleteContact(peopleWhoCanHelp);
            return RedirectToAction("Overview");
        }

        public ActionResult EditContact(int id)
        {
            var model = Db.Get(id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContact(PeopleWhoCanHelp peopleWhoCanHelp)
        {
            if (ModelState.IsValid)
            {
                Db.UpdateContact(peopleWhoCanHelp);
                return RedirectToAction("Details", new { id = peopleWhoCanHelp.Id });
            }
            return View(peopleWhoCanHelp);
        }


        [HttpGet]
        public ActionResult AddContacts()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContacts(PeopleWhoCanHelp peopleWhoCanHelp)
        {
            if (ModelState.IsValid)
            {
               // Db.AddContact(peopleWhoCanHelp);
                return RedirectToAction("Overview");
            }
            return View(peopleWhoCanHelp);
        }
    }
}