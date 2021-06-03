using System.Collections.Generic;
using System.Web;
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
            List<Chore> task = Db.GetAll();
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
            Chore task = Db.Get(id);
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
        public ActionResult Edit(Chore chore, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var file = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        ContentType = upload.ContentType,
                        chore = chore
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        file.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    Db.AddFile(file);

                    chore.Files.Add(file);
                }

                Db.Update(chore);
                return RedirectToAction("Details", new { id = chore.Id });
            }
            return View(chore);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chore task)
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