using ClassLibrary.Database;
using ClassLibrary.Models;
using System;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public class TeamPlayersParse : ITeamPlayersParse
    {
        public TeamPlayer ParsePlayerModel(PlayerModel playerModel)
        {
            TeamPlayer teamPlayer = new TeamPlayer();

            try
            {
                teamPlayer.PlayerID = playerModel.personID;
                teamPlayer.TeamID = playerModel.teamID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamPlayer;
        }
    }
}