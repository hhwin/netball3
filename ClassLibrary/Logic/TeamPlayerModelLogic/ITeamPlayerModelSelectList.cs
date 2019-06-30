using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamPlayerModelLogic
{
    public interface ITeamPlayerModelSelectList
    {
        IList<TeamPlayerModel> GetTeamPlayerModelList(int teamID);
    }
}