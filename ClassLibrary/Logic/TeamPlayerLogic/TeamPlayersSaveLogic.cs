using ClassLibrary.Database;
using ClassLibrary.Logic.CaptainLogic;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public class TeamPlayersSaveLogic : ITeamPlayersSaveLogic
    {
        ITeamPlayersUpdate _teamPlayersUpdate;
        ICheckCaptainLogic _checkCaptainLogic;
        ITeamPlayersInsert _teamPlayersInsert;

        public TeamPlayersSaveLogic(ITeamPlayersUpdate teamPlayersUpdate,
            ICheckCaptainLogic checkCaptainLogic,
            ITeamPlayersInsert teamPlayersInsert)
        {
            _teamPlayersUpdate = teamPlayersUpdate;
            _checkCaptainLogic = checkCaptainLogic;
            _teamPlayersInsert = teamPlayersInsert;
        }
        public void TeamPlayerSave(TeamPlayer teamPlayer,
            ref string message)
        {
            if (!teamPlayer.CaptainInd || (_checkCaptainLogic.CheckCaptain(teamPlayer.TeamID, teamPlayer.PlayerID) && teamPlayer.CaptainInd))
            {
                if (teamPlayer.TeamPlayerID > 0)
                {
                    _teamPlayersUpdate.TeamPlayersUpdateTransaction(teamPlayer);
                }
                else
                {
                    _teamPlayersInsert.TeamPlayerInsert(teamPlayer);
                }
            }
            else
            {
                message = "<script>alert('Captain has already been assigned. Only one captain per team.');</script>";
            }
        }
    }
}