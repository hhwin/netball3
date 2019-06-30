using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface IGetCoachModelLogic
    {
        CoachModel GetActiveCoachModel(int coachPersonID, int teamID);
        CoachModel GetActiveCoachModel(int teamID);
    }
}