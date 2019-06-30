using ClassLibrary.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.PersonLogic
{
    public class PersonDelete : IPersonDelete
    {
        /// <summary>
        /// Deletes a given Person object. 
        /// </summary>
        /// <param name="Person"></param> 

        public void PersonRemove(Person person)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(person).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PersonRemove(int personID)
        {
            Person person = new Person();
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    person = context.People
                        .Where(p => p.PersonID == personID)
                        .FirstOrDefault();

                    if (person != null)
                    {
                        context.Entry(person).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Person could not be found for personID " + personID.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
