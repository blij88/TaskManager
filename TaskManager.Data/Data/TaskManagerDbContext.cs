using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<models.Task> Tasks { get; set; }
        public DbSet<PeopleWhoCanHelp> Contacts { get; set; }
    }
}
