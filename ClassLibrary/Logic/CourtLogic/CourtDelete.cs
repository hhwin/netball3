namespace ClassLibrary.Logic.Court
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class CourtDelete : ICourtDelete
    {
        /// <summary>          
        /// Deletes a given Court object.           
        /// </summary>          
        /// <param name="Court"></param>              

        public void CourtRemove(Court court)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(court).State = EntityState.Deleted; context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

