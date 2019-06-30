
namespace ClassLibrary.Logic.Division
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class DivisionInsert : IDivisionInsert
    {
        /// <summary>
        /// Insert a Division object in Division table returning DivisionID if successful.
        /// DivisionID = null if failed.
        /// </summary>
        /// <param name="Division"></param>
        /// <returns></returns>
        public int? DivisionAdd(Division division)
        {
            int? divisionID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(division).State = EntityState.Added;
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
