using ClassLibrary.Database;
using ClassLibrary.Logic.AwardPersonModelLogic;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.AwardPersonModelLogic
{
    internal class AwardPersonListToAwardPersonModelListConverter
    {
        private AwardPersonToAwardPersonModelConverter _awardPersonToAwardPersonModelConverter;
        public AwardPersonListToAwardPersonModelListConverter()
        {
            _awardPersonToAwardPersonModelConverter = new AwardPersonToAwardPersonModelConverter();
        }
        internal IList<AwardPersonModel>AwardPersonListToAwardPersonModelListConvert(List<AwardPerson>awardPersonList)
        {
            IList<AwardPersonModel> awardPersonModelList = new List<AwardPersonModel>();
            foreach(AwardPerson awardPerson in awardPersonList)
            {
                AwardPersonModel awardPersonModel = new AwardPersonModel();
                awardPersonModel = _awardPersonToAwardPersonModelConverter.AwardPersonListToAwardPersonModelListConvert(awardPerson);
                awardPersonModelList.Add(awardPersonModel);
            }
            return awardPersonModelList;
        }
    }
}
