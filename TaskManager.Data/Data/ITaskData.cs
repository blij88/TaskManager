using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public interface ITaskData
    {
        List<Task> GetAll();
        void Add(Task task);
        Task Get(int id);
        void Delete(Task task);
        void Update(Task task);

    }
}
