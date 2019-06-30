
namespace ClassLibrary.Logic.Coach
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class CoachDelete : ICoachDelete
    {
        /// <summary>
        /// Deletes a given Coach object. 
        /// </summary>
        /// <param name="coach"></param>
        public void CoachRemove(Coach coach)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(coach).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}