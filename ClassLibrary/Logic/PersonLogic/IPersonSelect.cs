using System.Collections.Generic;

namespace ClassLibrary.Logic.PersonLogic
{
    public interface IPersonSelect
    {
        Database.Person GetPerson(int personID);
        IList<Database.Person> GetPersonList();
        Database.Person GetPerson(string firstName, string lastName);
    }
}