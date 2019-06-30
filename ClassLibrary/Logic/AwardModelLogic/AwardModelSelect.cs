using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.Models;
using System.Threading.Tasks;
using ClassLibrary.ModelLogic.AwardModelLogic;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelSelect : IAwardModelSelect
    {
        private AwardSelect awardSelect;
        private AwardToAwardModelConverter awardToAwardModelConverter;
        private AwardListToAwardModelListConverter awardListToAwardModelListConverter;

        public AwardModelSelect()
        {
            awardSelect = new AwardSelect();
            awardToAwardModelConverter = new AwardToAwardModelConverter();
            awardListToAwardModelListConverter = new AwardListToAwardModelListConverter();
        }

        public async Task<AwardModel> GetAwardModel(int awardID)
        {
            return awardToAwardModelConverter.ConvertToAwardModel(await awardSelect.GetAward(awardID));
        }

        public async Task<AwardModel>GetAwardModelByAwardName(string awardName)
        {
            return awardToAwardModelConverter.ConvertToAwardModel(await awardSelect.GetAwardByAwardName(awardName));
        }
    }
}
