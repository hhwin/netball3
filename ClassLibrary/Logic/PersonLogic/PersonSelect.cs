
namespace ClassLibrary.Logic.PersonLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get person details including person details.
    /// </summary>
    public class PersonSelect : IPersonSelect
    {
        public Person GetPerson(int personID)
        {
            Person person = new Person();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    person = context.People
                        .Where(c => c.PersonID == personID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public IList<Person> GetPersonList()
        {
            IList<Person> personList = new List<Person>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    personList = context.People
                        .OrderBy(p => p.FirstName)
                        .ThenBy(p => p.LastName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return personList;
        }
        public Person GetPerson(string firstName, string lastName)
        {
            Person person = new Person();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    person = context.People
                        .Where(c => c.FirstName.Trim().ToLower() == firstName.Trim().ToLower() && c.LastName.Trim().ToLower() == lastName.Trim().ToLower())
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }
    }
}