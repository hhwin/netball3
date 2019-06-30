using System;
using ClassLibrary.Models;
using ClassLibrary.Database;
using ClassLibrary.Logic.AwardModelLogic;
using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.ModelLogic.AwardModelLogic;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelUpdateLogic : IAwardModelUpdateLogic
    {
        private IAwardModelToAwardConverter _awardModelToAwardConverter; 
        private IAwardUpdate _awardUpdate;

        public AwardModelUpdateLogic(IAwardUpdate awardUpdate, 
                                    IAwardModelToAwardConverter awardModelToAwardConverter)
        {
            _awardUpdate = awardUpdate;
            _awardModelToAwardConverter = awardModelToAwardConverter;
        }

        public void UpdateAwardModel(AwardModel awardModel)
        {           
            Award award = _awardModelToAwardConverter.ConvertToAward(awardModel);
            _awardUpdate.AwardUpdateTransaction(award);
        }

    }

}
