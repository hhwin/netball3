using ClassLibrary.Database;
using ClassLibrary.Logic.TeamPlayerLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.CaptainLogic
{
    public class CaptainSelectList : ICaptainSelectList
    {
        /// <summary>
        /// Populates drop down list - team players for team ID in drop down list
        /// with the current captain being selected.
        /// </summary>
        TeamPlayersSelect _teamPlayersSelect;
        CaptainSelect _captainSelect;

        public CaptainSelectList(TeamPlayersSelect teamPlayersSelect,
            CaptainSelect captainSelect)
        {
            _teamPlayersSelect = teamPlayersSelect;
            _captainSelect = captainSelect;
        }
        public List<SelectListItem> GetCaptainSelectList(int teamID,
            string text = "-- Select team player for captain --")
        {
            IList<TeamPlayer> teamPlayerList = _teamPlayersSelect.GetTeamPlayerList(teamID);
            List<SelectListItem> teamPlayerItem = new List<SelectListItem>();
            PlayerModel playerModel = _captainSelect.GetCaptain(teamID);

            teamPlayerItem.Add(new SelectListItem
            {
                Text = text,
                Value = "0",
                Selected = (playerModel == null)
            });

            foreach (TeamPlayer teamPlayer in teamPlayerList)
                teamPlayerItem.Add(new SelectListItem
                {
                    Text = teamPlayer.Person.FirstName + " " + teamPlayer.Person.LastName + (teamPlayer.Person.PersonID == playerModel.personID?" (captain)":""),
                    Value = teamPlayer.Person.PersonID.ToString(),
                    Selected = (teamPlayer.Person.PersonID == playerModel.personID)
                });

            return teamPlayerItem;
        }

    }
}