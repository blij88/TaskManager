using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Data
{
    public interface ITaskData
    {
        IEnumerable<Task> GetAll();

    }
}
