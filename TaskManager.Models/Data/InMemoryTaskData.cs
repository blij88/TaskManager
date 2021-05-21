using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Models.Data
{
    public class InMemoryTaskData : ITaskData
    {
        List<Task> Tasks;
        public InMemoryTaskData ()
        {
            Tasks = new List<Task>
            {
                new Task {Name = "Groceries", Description = "at Lidl", StartDate = DateTime.Today, EndDate = new DateTime(21-05-2021), Progress = Progress.ToDo},
                new Task {Name = "Read", Description = "Introduction to C#", StartDate = DateTime.Today, EndDate = new DateTime(22-05-2021), Progress = Progress.Doing},
                new Task {Name = "Clean Computer", Description = "so Dirty", StartDate = DateTime.Today, EndDate = new DateTime(21-05-2021), Progress = Progress.Done}
            };
        }
        public IEnumerable<Task> GetAll()
        {
            return Tasks.OrderBy(t => t.Name);
        }
    }
}
