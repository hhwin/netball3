using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public interface IGetCoachModelListByTeamLogic
    {
        IList<CoachModel> GetCoachModelByTeamID(int teamID);
        IList<CoachModel> GetCoachModelByTeamName(string teamName);
    }
}