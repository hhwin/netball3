
namespace ClassLibrary.Logic.Coach
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class CoachInsert : ICoachInsert
    {
        /// <summary>
        /// Insert a coach object in Coach table returning coachID if successful.
        /// CoachID = null if failed.
        /// </summary>
        /// <param name="coach"></param>
        /// <returns></returns>
        public int? CoachAdd(Coach coach)
        {
            int? coachID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(coach).State = EntityState.Added;
                    context.SaveChanges();
                    coachID = coach.CoachID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachID;
        }
    }
}