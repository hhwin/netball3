using ClassLibrary.Database;
using ClassLibrary.Logic.Coach;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelInsertLogic : ICoachModelInsertLogic
    {
        private IPersonInsert _personInsert;
        private IPersonUpdate _personUpdate;
        private ICoachModelParseLogic _coachModelParseLogic;
        private ICoachInsert _coachInsert;

        public CoachModelInsertLogic(IPersonInsert personInsert,
            IPersonUpdate personUpdate,
            ICoachModelParseLogic coachModelParseLogic,
            ICoachInsert coachInsert)
        {
            _personInsert = personInsert;
            _personUpdate = personUpdate;
            _coachModelParseLogic = coachModelParseLogic;
            _coachInsert = coachInsert;
        }

        public void InsertCoachModel(CoachModel coachModel)
        {
            Person person;
            Database.Coach coach;

            person = _coachModelParseLogic.ParsePerson(coachModel);

            if (person.PersonID == 0)
            {
                _personInsert.PersonAdd(person);
            }
            else
            {
                _personUpdate.PersonUpdateTransaction(person);
            }

            coach = _coachModelParseLogic.ParseCoach(coachModel);
            _coachInsert.CoachAdd(coach);
        }
    }
}