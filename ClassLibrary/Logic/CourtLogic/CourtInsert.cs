
namespace ClassLibrary.Logic.Court
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class CourtInsert : ICourtInsert
    {
        /// <summary>
        /// Insert a Court object in Court table returning CourtID if successful.
        /// CourtID = null if failed.
        /// </summary>
        /// <param name="Court"></param>
        /// <returns></returns>
        public int? CourtAdd(Court court)
        {
            int? courtID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(court).State = EntityState.Added;
                    context.SaveChanges();
                    courtID = court.CourtID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return courtID;
        }
    }
}
