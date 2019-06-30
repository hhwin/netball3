using ClassLibrary.Database;
using ClassLibrary.Models;
using ClassLibrary.ModelLogic.AwardModelLogic;
using System.Collections.Generic;

namespace ClassLibrary.Logic.AwardModelLogic
{
    internal class AwardListToAwardModelListConverter
    {
        internal List<AwardModel> AwardListToAwardModelListConvert(IList<Award>awardList)
        {
            List<AwardModel> awardModelList = new List<AwardModel>();
            AwardToAwardModelConverter awardToAwardModelConverter = new AwardToAwardModelConverter();

            foreach (Award award in awardList)
            {
                AwardModel awardModel = new AwardModel();
                awardModel = awardToAwardModelConverter.ConvertToAwardModel(award);
                awardModelList.Add(awardModel);
            }
            return awardModelList;
        }
    }
}
