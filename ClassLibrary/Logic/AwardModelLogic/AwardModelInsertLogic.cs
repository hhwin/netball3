using System;
using ClassLibrary.Models;
using ClassLibrary.Database;
using ClassLibrary.Logic.AwardModelLogic;
using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.ModelLogic.AwardModelLogic;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelInsertLogic : IAwardModelInsertLogic
    {
        private IAwardModelToAwardConverter _awardModelToAwardConverter;
        private IAwardInsert _awardInsert;

        public AwardModelInsertLogic(IAwardInsert awardInsert, 
                                    IAwardModelToAwardConverter awardModelToAwardConverter)
        {
            _awardInsert = awardInsert;
            _awardModelToAwardConverter = awardModelToAwardConverter;
        }

        public void InsertAwardModel(AwardModel awardModel)
        {           
            Award award = _awardModelToAwardConverter.ConvertToAward(awardModel);
            _awardInsert.AwardAdd(award);
        }

    }

}
