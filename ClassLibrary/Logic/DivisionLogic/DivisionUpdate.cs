
namespace ClassLibrary.Logic.Division
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class DivisionUpdate : IDivisionUpdate
    {
        public int? DivisionUpdateTransaction(Division division)
        {
            int? divisionID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(division).State = EntityState.Modified;
                    context.SaveChanges();
                    divisionID = division.DivisionID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return divisionID;
        }
    }
}
