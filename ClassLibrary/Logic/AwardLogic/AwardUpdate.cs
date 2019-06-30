using System;
using ClassLibrary.Database;
using System.Data.Entity;

namespace ClassLibrary.Logic.AwardLogic
{
    public class AwardUpdate
    {
        public int? AwardUpdateTransaction(Award award)
        {
            int? awardID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(award).State = EntityState.Modified;
                    context.SaveChanges();
                    awardID = award.AwardID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return awardID;
        }
    }
}
