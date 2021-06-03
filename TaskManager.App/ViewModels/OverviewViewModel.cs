using System;
using System.Collections.Generic;
using System.Diagnostics;
using TaskManager.Data;

namespace TaskManager.App.ViewModels
{
    public class OverviewViewModel : Data.models.Chore
    {
        public List<Data.models.Chore> Task { get; set; }
        public List<Data.models.Chore> ToDo { get; } = new List<Data.models.Chore>();
        public List<Data.models.Chore> Doing { get; } = new List<Data.models.Chore>();
        public List<Data.models.Chore> Done { get; } = new List<Data.models.Chore>();
        public List<Data.models.PeopleWhoCanHelp> Contacts { get; set; } = new List<Data.models.PeopleWhoCanHelp>();

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

        private void ContactsListing()
        {
            foreach (var contact in Contacts)
            {
                // Do something?
                // It saves to database.
                // Assuming I can pull from database, I need to somehow get this into the OverViewModel below,
                //      even though that at the moment is hard coded to only take task related stuff.
            }
        }

        public OverviewViewModel(List<Data.models.Chore> task)
        {
            Task = task;
            SplitTask();
        }


    }
}