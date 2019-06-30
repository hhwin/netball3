using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.TeamPlayerModelLogic
{
    public class TeamPlayerModelSelectList : ITeamPlayerModelSelectList
    {
        public IList<TeamPlayerModel>GetTeamPlayerModelList(int teamID)
        {
            IList<TeamPlayerModel> teamPlayerModelList = new List<TeamPlayerModel>();
            using (NetballEntities context = new NetballEntities())
            {
                teamPlayerModelList = context.TeamPlayers
                    .Include(t => t.Team)
                    .Include(t => t.Person)
                    .Where(t => t.TeamID == teamID)
                    .Select(t => new TeamPlayerModel
                    {
                        teamID = t.TeamID,
                        playerID = t.PlayerID,
                        teamName = t.Team.TeamName,
                        playerName = t.Person.FirstName + " " + t.Person.LastName,
                        captainInd = t.CaptainInd,
                        email = t.Person.Email,
                        mobile = t.Person.Mobile
                    })
                    .ToList();
            }
            return teamPlayerModelList;
        }
    }
}
