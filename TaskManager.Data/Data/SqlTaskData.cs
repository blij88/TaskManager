using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class SqlTaskData : ITaskData
    {
        private readonly TaskManagerDbContext db;
        public SqlTaskData(TaskManagerDbContext db)
        {
            this.db = db;
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
    }
}
