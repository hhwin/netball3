using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;
using ClassLibrary.Database;
using ClassLibrary.Logic.TeamPlayerLogic;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class PlayerModelSaveLogic : IPlayerModelSaveLogic
    {
        /// <summary>
        /// Save player model and team player objects in database.
        /// </summary>
        private IPlayerModelListLogic _playerModelList;
        private IPlayerModelSelect _playerModelSelect;
        private IPlayerModelParse _playerModelParse;
        private ITeamPlayersSelect _teamPlayersSelect;
        private ICheckCaptainLogic _checkCaptainLogic;
        private IPlayerModelInsertLogic _insertPlayerModelLogic;
        private IUpdatePlayerModelLogic _updatePlayerModelLogic;
        private IPlayerModelCheckLogic _checkPlayerModelLogic;
        private IPersonSelect _personSelect;
        private ITeamPlayersSaveLogic _teamPlayersSaveLogic;

        public PlayerModelSaveLogic(IPlayerModelListLogic playerModelList,
            IPlayerModelSelect playerModelSelect,
            ICaptainSelect captainSelect,
            IPlayerModelParse playerModelParse,
            ITeamPlayersSelect teamPlayersSelect,
            ICheckCaptainLogic checkCaptainLogic,
            IPlayerModelInsertLogic insertPlayerModelLogic,
            IUpdatePlayerModelLogic updatePlayerModelLogic,
            IPlayerModelCheckLogic checkPlayerModelLogic,
            IPersonSelect personSelect,
            ITeamPlayersSaveLogic teamPlayersSaveLogic
        )
        {
            _playerModelList = playerModelList;
            _playerModelSelect = playerModelSelect;
            _playerModelParse = playerModelParse;
            _teamPlayersSelect = teamPlayersSelect;
            _checkCaptainLogic = checkCaptainLogic;
            _insertPlayerModelLogic = insertPlayerModelLogic;
            _updatePlayerModelLogic = updatePlayerModelLogic;
            _checkPlayerModelLogic = checkPlayerModelLogic;
            _personSelect = personSelect;
            _teamPlayersSaveLogic = teamPlayersSaveLogic;
        }

        public void PlayerModelSave(PlayerModel playerModel,
            ref string message)
        {
            TeamPlayer teamPlayer;
            Person person = new Person();

            if (_checkPlayerModelLogic.CheckPlayerModel(playerModel))
            {
                if (playerModel.personID > 0)
                {
                    _updatePlayerModelLogic.UpdatePlayerModel(playerModel);
                }
                else
                {
                    person = _personSelect.GetPerson(playerModel.firstName, playerModel.lastName);

                    if (person == null)
                    {
                        _insertPlayerModelLogic.InsertPlayerModel(ref playerModel);
                    }
                    else
                    {
                        playerModel.personID = person.PersonID;
                    }
                }

                if (_checkPlayerModelLogic.CheckPlayerModel(playerModel))
                {
                    teamPlayer = _teamPlayersSelect.GetTeamPlayer(playerModel.teamID, playerModel.personID);

                    if (teamPlayer == null)
                    {
                        teamPlayer = new TeamPlayer();
                        teamPlayer.TeamID = playerModel.teamID;
                        teamPlayer.PlayerID = playerModel.personID;
                    }

                    teamPlayer.CaptainInd = playerModel.captain;
                    _teamPlayersSaveLogic.TeamPlayerSave(teamPlayer, ref message);
                }
                else
                {
                    message = "<script>alert('Duplicate team player has been discovered. People must have unique names.');</script>";
                }
            }
        }
    }
}