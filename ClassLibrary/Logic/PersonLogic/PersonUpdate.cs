
namespace ClassLibrary.Logic.PersonLogic
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class PersonUpdate : IPersonUpdate
    {
        public int? PersonUpdateTransaction(Person person)
        {
            int? personID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(person).State = EntityState.Modified;
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
