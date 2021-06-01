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

        public void Add(Chore task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Delete(Chore task)
        {
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        public Chore Get(int id)
        {
            return db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<Chore> GetAll()
        {
            return db.Tasks.OrderBy(s => s.StartDate).ToList();
        }

        public void Update(Chore task)
        {
            var entry = db.Entry(task);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void AddContact(PeopleWhoCanHelp peopleWhoCanHelp)
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
