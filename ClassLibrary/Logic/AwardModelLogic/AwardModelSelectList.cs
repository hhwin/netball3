using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.Logic.AwardLogic.AwardModelLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelSelectList : IAwardModelSelectList
    {
        private AwardSelectList awardSelectList;
        private AwardListToAwardModelListConverter awardListToAwardModelListConverter;

        public AwardModelSelectList()
        {
            awardSelectList = new AwardSelectList();
            awardListToAwardModelListConverter = new AwardListToAwardModelListConverter();
        }

        public async Task<IList<AwardModel>> GetAwardModelList()
        {
            List<AwardModel> awardModelList = new List<AwardModel>();

            return awardListToAwardModelListConverter.AwardListToAwardModelListConvert(await awardSelectList.GetAwardList());
        }

        public async Task<IList<AwardModel>> GetAwardModelList(bool activeInd = true)
        {
            IList<AwardModel> awardModelList = new List<AwardModel>();

            return awardListToAwardModelListConverter.AwardListToAwardModelListConvert(await awardSelectList.GetAwardList(activeInd));
        }

        public async Task<IList<AwardModel>> GetAwardModelList(int? awardID)
        {
            IList<AwardModel> awardModelList = new List<AwardModel>();

            return awardListToAwardModelListConverter.AwardListToAwardModelListConvert(await awardSelectList.GetAwardList(awardID));
        }

    }
}
