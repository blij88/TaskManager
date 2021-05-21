using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Data
{
    public class InMemoryTaskData : ITaskData
    {
        List<Task> Tasks;
        public InMemoryTaskData ()
        {
            Tasks = new List<Task>
            {
                new Task {Id = 1, Name = "Groceries", Description = "at Lidl", StartDate = DateTime.Today, EndDate = new DateTime(2021,05,21), Progress = Progress.ToDo},
                new Task {Id = 2, Name = "Read", Description = "Introduction to C#", StartDate = new DateTime(2021,05,19), EndDate = new DateTime(2021,05,22), Progress = Progress.Doing},
                new Task {Id = 3, Name = "Clean Computer", Description = "so Dirty", StartDate = new DateTime(2021,05,23), EndDate = new DateTime(2021,05,24), Progress = Progress.Done}
            };
        }
        public IEnumerable<Task> GetAll()
        {
            return Tasks.OrderBy(t => t.StartDate);
        }
        public void Add(Task task)
        {
            Tasks.Add(task);
            task.Id = Tasks.Max(t => t.Id) + 1;
        }
        public Task Get(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }
        public void Delete(Task task) 
        {
            Tasks.Remove(task);
        }
    }
}
