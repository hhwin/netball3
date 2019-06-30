using ClassLibrary.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardLogic 
{
    internal class AwardSelectList
    {
        internal async Task<IList<Award>> GetAwardList()
        {
            IList<Award> awardList = new List<Award>();

            using (NetballEntities context = new NetballEntities())
            {
                awardList = await context.Awards
                    .ToListAsync();
            }
            return awardList;
        }

        internal async Task<IList<Award>>GetAwardList(bool? activeInd)
        {
            IList<Award> awardList = new List<Award>();

            using (NetballEntities context = new NetballEntities())
            {
                awardList = await context.Awards
                    .Where(a => a.ActiveInd == activeInd)
                    .ToListAsync();
            }
            return awardList;
        }

        internal async Task<IList<Award>> GetAwardList(int? awardID)
        {
            IList<Award> awardList = new List<Award>();

            using (NetballEntities context = new NetballEntities())
            {
                awardList = await context.Awards
                    .Where(a => a.AwardID == awardID)
                    .ToListAsync();
            }
            return awardList;
        }
    }
}
