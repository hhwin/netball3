using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.AwardPersonModelLogic
{
    internal class AwardPersonToAwardPersonModelConverter
    {
        internal AwardPersonModel AwardPersonListToAwardPersonModelListConvert(AwardPerson awardPerson)
        {
            AwardPersonModel awardPersonModel = new AwardPersonModel();

            if (awardPerson != null)
            {
                awardPersonModel.AwardID  = awardPerson.AwardID;
                awardPersonModel.AwardName = awardPerson.Award.AwardName;
                awardPersonModel.AwardPersonID = awardPerson.PersonID;
                awardPersonModel.FirstName = awardPerson.Person.FirstName;
                awardPersonModel.LastName = awardPerson.Person.LastName;
                awardPersonModel.MaidenName = awardPerson.Person.MiddleName;
                awardPersonModel.PersonID = awardPerson.PersonID;
                awardPersonModel.YearOfAward = awardPerson.YearAward;
            }
            return awardPersonModel;
        }
    }
}
