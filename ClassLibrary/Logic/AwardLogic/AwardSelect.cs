using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Database;

namespace ClassLibrary.Logic.AwardLogic
{
    internal class AwardSelect
    {
        internal async Task<Award> GetAward(int awardID)
        {
            Award award = new Award();

            using(NetballEntities context = new NetballEntities())
            {
                award = await context.Awards
                    .Where(a => a.AwardID == awardID)
                    .FirstOrDefaultAsync();      
                    }

            return award;
        }

        internal async Task<Award> GetAwardByAwardName(string awardName)
        {
            Award award = new Award();
            using (NetballEntities context = new NetballEntities())
            {
                award = await context.Awards
                    .Where(a => a.AwardName.ToLower() == awardName.ToLower())
                    .FirstOrDefaultAsync();
            }
            return award;
        }
    }
}
