using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Data.models;

namespace TaskManager.App.ViewModels
{
    public class EditViewModel
    {
        public Task task { get; set; }
        public List<PeopleWhoCanHelp> listPeopleWhoCanHelp { get; set; }
        public int PeopleWhoCanHelpId { get; set; }
    }
}