using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public class TaskDataRepository : ITaskData
    {
        private readonly TaskManagerDbContext db;
        public TaskDataRepository()
        {
            this.db = new TaskManagerDbContext();
        }

        public void Add(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Delete(Task task)
        {
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        public Task Get(int id)
        {
            return db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<Task> GetAll()
        {
            return db.Tasks.OrderBy(s => s.StartDate).ToList();
        }

        public void Update(Task task)
        {
            var entry = db.Entry(task);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateContact(PeopleWhoCanHelp peopleWhoCanHelp)
        {
            db.PeopleWhoCanHelps.Add(peopleWhoCanHelp);
            db.SaveChanges();
        }

        public void DeleteContact(PeopleWhoCanHelp peopleWhoCanHelp)
        {
            db.PeopleWhoCanHelps.Remove(peopleWhoCanHelp);
            db.SaveChanges();
        }

        public PeopleWhoCanHelp GetContact(int id)
        {
            return db.PeopleWhoCanHelps.FirstOrDefault(p => p.Id == id);
        }

        public List<PeopleWhoCanHelp> GetAllContacts()
        {
            return db.PeopleWhoCanHelps.OrderBy(p => p.Name).ToList();
        }

        public void UpdateContact(PeopleWhoCanHelp peopleWhoCanHelp)
        {
            var entry = db.Entry(peopleWhoCanHelp);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
