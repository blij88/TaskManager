using System.Collections.Generic;
using TaskManager.Data.models;

namespace TaskManager.Data
{
    public interface ITaskData
    {
        List<Chore> GetAll();
        void Add(Chore task);
        Chore Get(int id);
        void Delete(Chore task);
        void Update(Chore task);

        List<PeopleWhoCanHelp> GetAllContacts();
        void AddContact(PeopleWhoCanHelp peopleWhoCanHelp);
        PeopleWhoCanHelp GetContact(int id);
        void DeleteContact(PeopleWhoCanHelp peopleWhoCanHelp);
        void UpdateContact(PeopleWhoCanHelp peopleWhoCanHelp);

        void AddFile(File file);
    }
}
