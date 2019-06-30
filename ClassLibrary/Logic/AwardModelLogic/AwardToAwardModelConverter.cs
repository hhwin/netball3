using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.ModelLogic.AwardModelLogic
{
    internal class AwardToAwardModelConverter
    {
        internal AwardModel ConvertToAwardModel(Award award)
        {
            AwardModel awardModel = new AwardModel();

            awardModel.ActiveInd = award.ActiveInd??true;
            awardModel.AwardID = award.AwardID;
            awardModel.AwardName = award.AwardName;
            awardModel.Comments = award.Comments;

            return awardModel;
        }
    }
}
