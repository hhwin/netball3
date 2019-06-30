using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.Team
{
    public class TeamSelectList : TeamSelectLogic //, ITeamSelectList
    {
        public List<SelectListItem> GetTeamSelectList(int teamID = 0)
        {
            List<SelectListItem>teamItem = new List<SelectListItem>();
            IList<ClassLibrary.Database.Team> teamList = GetTeamList();
            
            teamItem.Add(new SelectListItem
            {
                Text = "-- Select team --",
                Value = "0",
                Selected = (teamID==0)
            });

            foreach (ClassLibrary.Database.Team team in teamList)
               teamItem.Add(new SelectListItem
                {
                    Text = team.TeamName,
                    Value = team.TeamID.ToString(),
                    Selected = (team.TeamID == teamID)
                });

            return teamItem;
        }

        public static List<SelectListItem> GetTeamSelectListStatic(int teamID)
        {
           TeamSelectList teamSelectList = new TeamSelectList();
            return teamSelectList.GetTeamSelectList(teamID);
        }
    }
}
