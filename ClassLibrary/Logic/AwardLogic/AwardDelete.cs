using ClassLibrary.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardLogic
{
    public class AwardDelete
    {
        public void AwardDeleteTransaction(int awardID)
        {
            Award award = new Award();

            using (NetballEntities context = new NetballEntities())
            {
                award = context.Awards
                    .Where(g => g.AwardID == awardID)
                    .FirstOrDefault();

                if (award != null)
                {
                    AwardDeleteTransaction(award);
                }
            }
        }

        public void AwardDeleteTransaction(Award award)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(award).State = EntityState.Deleted;
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
