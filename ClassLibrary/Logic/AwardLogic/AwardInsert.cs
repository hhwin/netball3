using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Database;
using System.Data.Entity;

namespace ClassLibrary.Logic.AwardLogic
{
    public class AwardInsert : IAwardInsert
    {
        public int? AwardAdd(Award award)
        {
            int? awardID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(award).State = EntityState.Added;
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
