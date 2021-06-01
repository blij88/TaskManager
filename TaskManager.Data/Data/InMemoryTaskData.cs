using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public class InMemoryTaskData// : ITaskData
    {
        readonly List<Chore> Tasks;
        public InMemoryTaskData()
        {
            Tasks = new List<Chore>
            {
                new Chore {Id = 1, Name = "Groceries", Description = "at Lidl", StartDate = DateTime.Today, EndDate = new DateTime(2021,05,21), Progress = Progress.ToDo},
                new Chore {Id = 2, Name = "Read", Description = "Introduction to C#", StartDate = new DateTime(2021,05,19), EndDate = new DateTime(2021,05,22), Progress = Progress.Doing},
                new Chore {Id = 3, Name = "Clean Computer", Description = "so Dirty", StartDate = new DateTime(2021,05,23), EndDate = new DateTime(2021,05,24), Progress = Progress.Done}
            };
        }
        public List<Chore> GetAll()
        {
            return Tasks.OrderBy(t => t.StartDate).ToList();
        }
        public void Add(Chore task)
        {
            Tasks.Add(task);
            task.Id = Tasks.Max(t => t.Id) + 1;
        }
        public Chore Get(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }
        public void Delete(Chore task)
        {
            Tasks.Remove(task);
        }
        public void Update(Chore task)
        {

        }
    }
}
