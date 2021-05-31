using System.Data.Entity;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<PeopleWhoCanHelp> PeopleWhoCanHelps { get; set; }
    }
}
