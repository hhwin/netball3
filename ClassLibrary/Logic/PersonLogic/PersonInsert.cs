
namespace ClassLibrary.Logic.PersonLogic
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class PersonInsert : IPersonInsert
    {
        /// <summary>
        /// Insert a Person object in Person table returning PersonID if successful.
        /// PersonID = null if failed.
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int? PersonAdd(Person person)
        {
            int? personID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(person).State = EntityState.Added;
                    context.SaveChanges();
                    personID = person.PersonID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return personID;
        }
    }
}
