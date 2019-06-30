using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface ICoachModelParseLogic
    {
        Database.Coach ParseCoach(CoachModel coachModel);
        CoachModel ParseCoachModel(Person person);
        Person ParsePerson(CoachModel coachModel);
    }
}