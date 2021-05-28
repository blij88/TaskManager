﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TaskManager.Data;

namespace TaskManager.App.ViewModels
{
    public class OverviewViewModel : Data.models.Task
    {
        public List<Data.models.Task> Task { get; set; }
        public List<Data.models.Task> ToDo { get; } = new List<Data.models.Task>();
        public List<Data.models.Task> Doing { get; } = new List<Data.models.Task>();
        public List<Data.models.Task> Done { get; } = new List<Data.models.Task>();
        public List<Data.models.Task> Late { get; } = new List<Data.models.Task>();
        public List<Data.models.PeopleWhoCanHelp> Contacts { get; } = new List<Data.models.PeopleWhoCanHelp>();


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

        private void ContactOverview()
        {
            foreach (var contact in Contacts)
            {
                // Do something?
            }
        }

        public OverviewViewModel(List<Data.models.Task> task)
        {
            Task = task;
            SplitTask();
            LateTask();
        }


    }
}