using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Data;
using TaskManager.Data.models;

namespace TaskManager.App.Logic
{
    public class LateLogic
    {
        public string Late(Chore chore)
        {
            if ((chore.Progress == Progress.ToDo && DateTime.Today> chore.StartDate )|| (chore.Progress!= Progress.Done && chore.EndDate <= DateTime.Today))
            {
                return "danger";
            }
            else
            {
                return "info";
            }
        }
    }
}