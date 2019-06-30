using ClassLibrary.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.DatabaseLogic.AwardPersonLogic
{
    internal class AwardPersonSelectList
    {
        internal IList<AwardPerson>GetAwardPersonList()
        {
            IList<AwardPerson> awardPersonList = new List<AwardPerson>();

            using (NetballEntities context = new NetballEntities())
            {
                awardPersonList = context.AwardPersons
                    .Include(a => a.Person)
                    .Include(a => a.Award)
                    .ToList();
            }
            return awardPersonList;
        }
    }
}
