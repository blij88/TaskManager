using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class TaskDataRepository : ITaskData
    {
        private readonly TaskManagerDbContext db;
        public TaskDataRepository()
        {
            this.db = new TaskManagerDbContext();
        }

        public void Add(models.Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public void Delete(models.Task task)
        {
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        public models.Task Get(int id)
        {
            return db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<models.Task> GetAll()
        {
            return db.Tasks.OrderBy(s => s.StartDate).ToList();
        }

        public void Update(models.Task task)
        {
            var entry = db.Entry(task);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
