using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface ICoachModelSelectTeam
    {
        CoachModel GetCoachModelSelectTeam(int teamID);
    }
}