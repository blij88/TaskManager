using System.Collections.Generic;
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

        List<PeopleWhoCanHelp> GetAllContacts();
        void AddContact(PeopleWhoCanHelp peopleWhoCanHelp);
        PeopleWhoCanHelp GetContact(int id);
        void DeleteContact(PeopleWhoCanHelp peopleWhoCanHelp);
        void UpdateContact(PeopleWhoCanHelp peopleWhoCanHelp);
    }
}
