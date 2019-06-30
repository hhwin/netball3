using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamModelLogic
{
    public interface ITeamModelListByDivisionLogic
    {
        IList<TeamModel> GetTeamModeListByDivision(int divisionID);
        IList<TeamModel> GetTeamModeListBasicsByDivision(int divisionID);
    }
}