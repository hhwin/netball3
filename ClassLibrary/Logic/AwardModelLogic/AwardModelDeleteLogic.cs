using ClassLibrary.Database;
using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.Logic.GamePlayerLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelDeleteLogic : IAwardModelDeleteLogic
    {

        private IAwardModelToAwardConverter _awardModelToAwardConverter;
        private IAwardDelete _awardDelete;

        public AwardModelDeleteLogic(IAwardDelete awardDelete,
                                     IAwardModelToAwardConverter awardModelToAwardConverter)
        {
            _awardDelete = awardDelete;
            _awardModelToAwardConverter = awardModelToAwardConverter;
        }

        public void DeleteAwardModel(AwardModel awardModel)
        {
            Award award = _awardModelToAwardConverter.ConvertToAward(awardModel);
            _awardDelete.AwardDeleteTransaction(award);
        }

        public void DeleteAwardModel(int awardID)
        {
            _awardDelete.AwardDeleteTransaction(awardID);
        }

     
    }
}