using ClassLibrary.Database;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public class TeamPlayerSelectList : TeamPlayersSelect, ITeamPlayerSelectList
    {
        public TeamPlayerSelectList()
        { }

        public List<SelectListItem> GetTeamPlayersSelectList(int teamID, 
            int personID = 0,
            string text = "-- Select team player --")
        {
            IList<TeamPlayer> teamPlayerList = GetTeamPlayerList(teamID);
            List<SelectListItem> teamPlayerItem = new List<SelectListItem>();

            teamPlayerItem.Add(new SelectListItem
            {
                Text = text,
                Value = "0",
                Selected = (personID == 0)
            });

            foreach (TeamPlayer teamPlayer in teamPlayerList)
                teamPlayerItem.Add(new SelectListItem
                {
                    Text = teamPlayer.Person.FirstName + " " + teamPlayer.Person.LastName,
                    Value = teamPlayer.Person.PersonID.ToString(),
                    Selected = (teamPlayer.Person.PersonID == personID)
                });

            return teamPlayerItem;
        }
        public static List<SelectListItem> GetTeamPlayersSelectStaticList(int teamID,
            int personID = 0,
            string text = "-- Select team player --")
        {
            TeamPlayerSelectList teamPlayerSelectList = new TeamPlayerSelectList();
            return teamPlayerSelectList.GetTeamPlayersSelectList(teamID, personID = 0, text);
        }
    }
}