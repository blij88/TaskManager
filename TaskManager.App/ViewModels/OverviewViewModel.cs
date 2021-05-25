using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TaskManager.Data;

namespace TaskManager.App.ViewModels
{
    public class OverviewViewModel: Task
    {
        public List<Task> Task{ get; set; }
        public List<Task> ToDo { get; } = new List<Task>();
        public List<Task> Doing { get;} = new List<Task>();
        public List<Task> Done { get;} = new List<Task>();
        public List<Task> Late { get;} = new List<Task>();


        private void SplitTask()
        {
            Debug.WriteLine($"Number of items in Task: {Task.Count}");
            foreach (var task in Task)
            {
                switch (task.Progress)
                {
                    case Progress.ToDo:
                        ToDo.Add(task);
                        break;
                    case Progress.Doing:
                        Doing.Add(task);
                        break;
                    case Progress.Done:
                        Done.Add(task);
                        break;
                    default:
                        break;
                }
            }
        }

        private void LateTask()
        {
            foreach (var task in Task)
            {            
                if ((task.StartDate.Date <= DateTime.Today.Date && task.Progress == Progress.ToDo) || (task.EndDate <= DateTime.Today && task.Progress != Progress.Done))
                {
                    Late.Add(task);
                }

            }
        }

        public OverviewViewModel(List<Task> task)
        {
            Task = task;
            SplitTask();
            LateTask();
        }


    }
}