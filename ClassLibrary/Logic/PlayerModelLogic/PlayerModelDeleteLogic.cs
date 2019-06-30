using ClassLibrary.Database;
using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.GamePlayerLogic;
using ClassLibrary.Logic.TeamPlayerLogic;
using System.Collections.Generic;

namespace ClassLibrary.Logic.PlayerModelLogic
{

    public class PlayerModelDeleteLogic : IPlayerModelDeleteLogic
    {
        private IGamePlayerSelect _gamePlayerSelect;
        private ITeamPlayersDelete _teamPlayersDelete;
        private ICheckCaptainLogic _checkCaptainLogic;

        public PlayerModelDeleteLogic(IGamePlayerSelect gamePlayerSelect,
            ITeamPlayersDelete teamPlayersDelete,
            ICheckCaptainLogic checkCaptainLogic)
        {
            _gamePlayerSelect = gamePlayerSelect;
            _teamPlayersDelete = teamPlayersDelete;
            _checkCaptainLogic = checkCaptainLogic;
        }

        private bool CheckGamePlayerList(int playerID, 
            int teamID)
        {
            IList<GamePlayer> gamePlayerList;
            gamePlayerList = _gamePlayerSelect.GetGamePlayerList(playerID, teamID);
            return (gamePlayerList == null || gamePlayerList.Count == 0);
        }

        public void PlayerModelDelete(int playerID,
            int teamID,
            ref string message)
        {
            if (CheckGamePlayerList(playerID, teamID))            
            {
                if (!_checkCaptainLogic.CheckCaptain(teamID, playerID))
                {
                    _teamPlayersDelete.TeamPlayersRemove(playerID, teamID);
                }
                else
                {
                    message = "Cannot delete player because player is captain of the team.";
                }
            }
            else
            {
                message = "Cannot delete player because player has game player fixtures.";
            }
        }
    }
}