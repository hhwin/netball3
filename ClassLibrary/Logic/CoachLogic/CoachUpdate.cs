
namespace ClassLibrary.Logic.Coach
{
    using System;
    using System.Data.Entity;
    using ClassLibrary.Database;

    public class CoachUpdate : ICoachUpdate
    {
        public int? CoachUpdateTransaction(Coach coach)
        {
            int? coachID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(coach).State = EntityState.Modified;
                    context.SaveChanges();
                    coachID = coach.CoachID;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return coachID;
        }
    }
}