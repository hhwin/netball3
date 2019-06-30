using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.TeamModelLogic
{
    public interface ITeamModelListLogic
    {
        IList<TeamModel> GetTeamModelList(int? teamID);
        IList<TeamModel> GetTeamModelList(string teamName);
    }
}