
namespace ClassLibrary.Logic.Court
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class CourtUpdate : ICourtUpdate
    {
        public int? CourtUpdateTransaction(Court court)
        {
            int? courtID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(court).State = EntityState.Modified;
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
