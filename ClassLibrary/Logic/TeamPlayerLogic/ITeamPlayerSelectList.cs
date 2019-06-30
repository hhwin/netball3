using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayerSelectList
    {
        List<SelectListItem> GetTeamPlayersSelectList(int teamID, 
            int personID = 0,
            string text = "-- Select team player --");
    }
}