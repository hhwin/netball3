using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.AwardModelLogic
{
    internal class AwardModelToAwardConverter
    {
        internal Award ConvertToAward(AwardModel awardModel)
        {
            Award award = new Award();
            award.ActiveInd = awardModel.ActiveInd;
            award.AwardID = awardModel.AwardID;
            award.AwardName = awardModel.AwardName;
            award.Comments = awardModel.Comments;

            return award;
        }
    }
}
